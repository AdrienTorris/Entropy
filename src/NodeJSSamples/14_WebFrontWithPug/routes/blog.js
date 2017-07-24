var express = require('express');
var router = express.Router();
var MongoClient = require('mongodb').MongoClient, assert = require('assert');
var objectID = require('mongodb').ObjectID;


var url = 'mongodb://127.0.0.1:27017/BlogTest';


router.get('/', function(req, res, next) {

    // Use connect method to connect to the server
    MongoClient.connect(url, function(err,db){

        // Ensure we've connected
        assert.equal(null,err);

        var posts = db.collection('posts');
        posts.find({}).toArray(function(err, postsResult){
            if (err) {
                res.send(err);
            } else if (postsResult.length) {
                // console.log('postsResult')
                // console.log(postsResult)
                // console.log('postsResult[0]')
                // console.log(postsResult[0])
                // console.log('postsResult[0].title')
                // console.log(postsResult[0].title)
                res.render('blog', { 
                    'posts': postsResult
                });
            } else {
                res.send('No documents found');
            }
            db.close();
        });
        
        
    });

});

 router.get('/:id', function(req, res, next){
     // Use connect method to connect to the server
    MongoClient.connect(url, function(err,db){

        // Ensure we've connected
        assert.equal(null,err);

        var posts = db.collection('posts');
        // console.log('req.params.id')
        // console.log(req.params.id)
        var postId = req.params.id;
        // console.log('postId')
        // console.log(postId)
        // console.log(postId === 1)
        // console.log(parseInt(postId) === 1)
        posts.findOne({id:parseInt(postId)}, function(err, post){
            if(err){
                console.log(err);
            }else{
                // console.log('post')
                // console.log(post)
                res.render('post', { 
                    'post': post
                 });
            }
                db.close();
        });
    });
 });

module.exports = router;