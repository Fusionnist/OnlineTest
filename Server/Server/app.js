const port = 30000;

global.io = require("socket.io").listen(port);

console.log(`Server listening on port ${port}`);

require("./util/eventLoader")();