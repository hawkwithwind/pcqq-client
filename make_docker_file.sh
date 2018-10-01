cat <<EOF > $1
FROM $2
COPY $3/* /home/myapp/
ENTRYPOINT ["mono"]
CMD ["$4"]
EOF
