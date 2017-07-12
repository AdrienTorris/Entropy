var async = require('async');
var fs = require('fs');

async.map(['file1','file2','file3'],fs.stat,function(err,results){
    console.log('map');
    console.log('results: '+results);
    console.log('err: '+err);
});

async.filter(['file1','file2','file3'],fs.exists,function(results){
    console.log('filter');
    console.log('results: '+results);
});

async.filter(['file3'],fs.exists,function(results){
    console.log('filter');
    console.log('results: '+results);
});

async.filter(['file1'],fs.exists,function(results){
    console.log('filter');
    console.log('results: '+results);
});

async.filter(['file1','file2'],fs.exists,function(results){
    console.log('filter');
    console.log('results: '+results);
});