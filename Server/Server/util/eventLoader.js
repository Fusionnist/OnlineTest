const reqEvent = event => require(`../events/${event}`);
module.exports = () => {
    global.io.on("connection", socket => {
        console.log(`[${socket.id}] New socket`);
        socket.user = {};
        socket.user.pos = { x: 0, y: 0 };
        socket.on("updatePos", data => reqEvent("updatePos")(socket, data));
    });
}