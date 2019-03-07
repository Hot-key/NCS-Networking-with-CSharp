///SuperSocket_createBuffer(type, SendTo);
var buffer = buffer_create(1024, buffer_grow, 1);
buffer_write(buffer, buffer_u32, 0);
buffer_write(buffer, buffer_s16, argument1);
buffer_write(buffer, buffer_s16, argument0);
return buffer;

if(argument1 == SuperSocket.SendToClient)or(argument1 == SuperSocket.SendToAll) {
    global.buffer_mode = true;
}
