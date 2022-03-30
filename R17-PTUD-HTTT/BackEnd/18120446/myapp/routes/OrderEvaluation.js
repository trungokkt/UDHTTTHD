const express = require("express");
const { route } = require(".");
const router = express.Router();

// http://locahost/OrderEvaluation
router.get("/", (req, res) => {
  res.render("OrderEvaluation/OrderEvaluation", { title: "Order" });
});
// http://locahost/OrderEvaluation/1
router.get("/:id", (req, res) => {
  const { id } = req.params;

  //console.log(req.params);
  res.render("OrderEvaluation.hbs", { title: "OrderEvaluation" });
});


module.exports = router;
