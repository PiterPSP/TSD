FROM ubuntu:18.04
COPY hello.sh /
ARG $NAME
RUN chmod +x /hello.sh
ENTRYPOINT ["/hello.sh"]
CMD [$NAME]