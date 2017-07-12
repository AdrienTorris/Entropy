var request = require('request');
var fs = require("fs");

// Grab a page
request('https://adrientorris.github.io', function(error,response,body){
    if(!error && response.statusCode==200){
        console.log(body);
    }
});

// Download a picture
var file = fs.createWriteStream('test.png');
request('https://adrientorris.github.io/wwwroot/images/aspnet-core/how-setup-angular-2-typescript-project-visual-studio-2017-010.png').pipe(file);
file.on('finish',function(){
    console.log('Picture downloaded.');
});