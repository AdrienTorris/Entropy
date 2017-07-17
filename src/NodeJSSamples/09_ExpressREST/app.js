var express = require('express');
var app = express();

app.get('/', function(req, res){
    res.json({message: 'Welcome to this API ! :)'});
});

app.get('/about', function(req, res){
    res.json({message: 'You\'re on the about page'});
});

app.listen(process.env.PORT || 8000);