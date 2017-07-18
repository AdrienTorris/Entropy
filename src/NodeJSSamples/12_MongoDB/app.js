var MongoClient = require('mongodb').MongoClient, assert = require('assert');
var objectID = require('mongodb').ObjectID;

// Connection URL for local mongodb server
var url = 'mongodb://127.0.0.1:27017/NASA';
// Source of the data: http://api.open-notify.org/astros.json

// Use connect method to connect to the server
MongoClient.connect(url, function(err,db){

    // Ensure we've connected
    assert.equal(null,err);

    var peopleInSpace = db.collection('peopleInSpace');

    peopleInSpace.count({},function(err, result){
        if(err)throw err;
        console.log('Nb person in space right now: ' + result);
    });

    // peopleInSpace.findOne({},function(err,result){
    //     console.log(result.craft);
    // });

    // Get all people in space
    var cursor = peopleInSpace.find({});
    let i = 0;
    cursor.each(function(err, item) {
        i++;
        if(i===1){
            console.log('\n\npeople in the space:');
        }
        if(item == null) {
            return;
        }

        console.log(item.name);
    });

    // Get all people in the ISS
    var peopleInTheISSCursor = peopleInSpace.find({craft:'ISS'});
    let i2=0;
    peopleInTheISSCursor.each(function(err, item) {
        i2++;
        if(i2===1){
            console.log('\n\npeople in the ISS:');
        }
        if(item == null) {
            return;
        }

        console.log(item.name);
    });
});