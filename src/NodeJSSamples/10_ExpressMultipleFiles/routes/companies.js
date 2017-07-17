var express = require('express');
var router = express.Router();

/* GET companies listing. */
router.get('/', function(req, res, next) {
  res.send('Here the companies');
});

module.exports = router;