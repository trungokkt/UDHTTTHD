const express = require("express");
const { route } = require(".");
const router = express.Router();

// http://locahost/products
router.get("/", (req, res) => {
  res.render("products/list-products", { title: "Product View" });
});
// http://locahost/products/1
router.get("/ProductType", (req, res) => {
  
  res.render("products/ProductType", { title: "Product Type Create" });
});
router.get("/create", (req, res) => {
  
  res.render("products/create-products", { title: "Product Create" });
});
router.get("/del", (req, res) => {
  
  res.render("products/deleted-products", { title: "Product Deleted" });
});
router.get("/:id", (req, res) => {
  // req.query  http://locahost/products?title=Samsung
  // req.params;  http://locahost/products/:id
  // req.body; Post
  const { id } = req.params;

  //console.log(req.params);
  res.render("products/detail-products", { title: "Product View " + id });
});
router.get("/:id/edit", (req, res) => {
  const { id } = req.params;

  //console.log(req.params);
  res.render("products/edit-products", { title: "Product Edit" + id });
});


module.exports = router;
