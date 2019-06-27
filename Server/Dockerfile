FROM mono:latest

RUN mono --version
ADD . . 
RUN msbuild NCS.sln

CMD [ "mono",  "./NCS.ConsoleTest/bin/Debug/Ncs.ConsoleTest.exe" ]