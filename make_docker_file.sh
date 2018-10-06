cat <<EOF > $1
FROM $2
COPY $3/* /home/myapp/
COPY ./config.json /home/myapp/config.json
ENTRYPOINT ["mono"]
CMD ["$4"]
EOF
