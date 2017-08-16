let express = require('express'),
    port = 1886,
    app = express(),
    edge = require('edge'),
    logic = edge.func({
        source: require('path').join(__dirname, 'mainLogic.csx'),
        references: [
            'System.Windows.Forms.dll'
        ]
    });

app.get('/controller', (req, res) => {
    res.sendFile('views/controller.html', { root: __dirname });
});
app.get('/img/icon_down.png', (req, res) => {
    res.sendFile('views/img/icon_down.png', { root: __dirname });
});
app.get('/img/icon_mute.png', (req, res) => {
    res.sendFile('views/img/icon_mute.png', { root: __dirname });
});
app.get('/img/icon_up.png', (req, res) => {
    res.sendFile('views/img/icon_up.png', { root: __dirname });
});

app.get('/control/:task', (req, res) => {
    let task = Number(req.params.task);

    logic(task, (error, result) => {
        if (error) console.log(error);
        res.end(result);
    });
});

app.listen(
    port,
    () => {
        console.log(
            `
                     listening on: http://localhost:${port}/controller/

            for direct access use: http://localhost:${port}/control/{task}

            task must be:
                0 - to mute sound
                1 - volume down
                2 - volume up
            `);
    }
);