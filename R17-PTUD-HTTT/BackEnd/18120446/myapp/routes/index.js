const express = require("express");
const router = express.Router();

/* GET home page. */
router.get("/", function (req, res, next) {
  res.render("index", { title: "Express" });
});

// router.get("/products", function (req, res, next) {
//   res.render("products/list-products", { title: "Product View" });
// });

module.exports = router;
