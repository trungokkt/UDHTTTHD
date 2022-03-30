const express = require("express");
const { route } = require(".");
const router = express.Router();


router.get("/", (req, res) => {
  res.render("Store/Store", { title: "Store" });
});
router.get("/create", (req, res) => {
    res.render("Store/Store", { title: "Store" });
  });


module.exports = router;
