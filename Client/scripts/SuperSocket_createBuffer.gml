///SuperSocket_createBuffer(type);
var buffer = buffer_create(1024, buffer_grow, 1);
buffer_write(buffer, buffer_u32, 0);
buffer_write(buffer, buffer_s16, argument0);
return buffer;
