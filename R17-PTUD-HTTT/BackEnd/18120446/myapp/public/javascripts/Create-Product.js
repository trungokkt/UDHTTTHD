$(document).ready(function () {
  const id = getId();
  var temp ='' ;
  console.log(id);
 
 


  $("#my-form").submit((e) => {
    e.preventDefault();
    //POST
   
    
    $.ajax({
      url: "https://localhost:44357/api/Products/add",
      type: "post",
      contentType:"application/json",
      dataType: "application/json",
      data: JSON.stringify({
        
        productName: $("#ProductName").val(),
        productDescription: $("#productDescription").val(),
        productPrice: parseInt($("#productPrice").val()),
        productInventory:  parseInt($("#productInventory").val()),
        productTypeId:  parseInt($("#productTypeId").val()),
        productIsDelete: 0})
      ,
      success: function (result) {
       
        console.log(result);
        $("#user-id").val(result.productName);
        $("#title").val(result.productDescription);
        $("#body").val(result.productPrice);
        location.href = "products";
      },
      
      error: function (xhr, status, err) {
        console.log({ xhr, status, err });
        if (err == "No conversion from text to application/json") location.href = "/products";
        
        //alert(err);
      },
    });
    
   
//     temp = JSON.stringify({
      
//       productName: $("#ProductName").val(),
//       productDescription: $("#productDescription").val(),
//       productPrice: parseInt($("#productPrice").val(),10),
//       productInventory:  parseInt($("#productInventory").val(),10),
//       productTypeId:  parseInt($("#productTypeId").val(),10),
//       productIsDelete: 0})
//   console.log(temp);
  });
});

getId = () => {
  const url = location.href;
  const stuff = url.split("/");
  return stuff[4];
};
