var fs = require('fs');

fs.readFile('bigfile.json', function (err, buf) {
    console.log(buf.toString());
});