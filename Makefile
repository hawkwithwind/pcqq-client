

MONO_IMAGE=mono-pcqq
BUILD_PATH=build
RUNTIME_PATH=target

PROJECT=QQGRPCRobot
PROJECT_IMAGE=qqgrpcrobot
BUILD_CONFIG=Debug


build-runtime: $(RUNTIME_PATH)/$(BUILD_CONFIG) $(RUNTIME_PATH)/dockerfile
	docker build -t $(PROJECT_IMAGE) $(RUNTIME_PATH)

$(RUNTIME_PATH)/$(BUILD_CONFIG): $(BUILD_PATH)/BIN $(RUNTIME_PATH)
	cp -R $(BUILD_PATH)/$(PROJECT)/bin/$(BUILD_CONFIG) $(RUNTIME_PATH)/$(BUILD_CONFIG) && \
	cp config.json $(RUNTIME_PATH)/config.json

$(RUNTIME_PATH)/dockerfile: mono-image
	sh make_docker_file.sh $(RUNTIME_PATH)/Dockerfile $(MONO_IMAGE) $(BUILD_CONFIG) $(PROJECT).exe

$(BUILD_PATH)/BIN: $(BUILD_PATH)/READY mono-image
	docker run --rm \
	-v $(shell pwd)/$(BUILD_PATH):/home/myapp \
	$(MONO_IMAGE) $(PROJECT)/$(PROJECT).csproj

mono-image:
	docker build -t $(MONO_IMAGE) docker/

$(BUILD_PATH)/READY: $(BUILD_PATH)
	cp -R PCQQ-Protocol/QQ.Framework $(BUILD_PATH)/QQ.Framework && \
	cp -R proto $(BUILD_PATH)/proto && \
	cp -R $(PROJECT) $(BUILD_PATH)/$(PROJECT) && \
	patch -N $(BUILD_PATH)/QQ.Framework/QQ.Framework.csproj < patch/QQ.Framework.csproj.patch || true

$(BUILD_PATH):
	[ -d $(BUILD_PATH) ] || mkdir $(BUILD_PATH)

$(RUNTIME_PATH) :
	[ -d $(RUNTIME_PATH) ] || mkdir $(RUNTIME_PATH)

clean:
	rm -rf $(RUNTIME_PATH) $(BUILD_PATH)

