$(document).ready(function (){ 
 
  $.ajax({
    url: "https://localhost:44357/api/products",
    type: "get",
    success: function (result) {
      result.forEach((element) => {
        $("#body-table").append(` <tr>
        <td>${element.productName}</td>
        <td>${element.productDescription}</td>
        <td>${element.productPrice}</td>
        <td>${element.productInventory}</td>
        <td>${element.productTypeId}</td>
        <td><a href="/products/${element.productId}/edit" class="btn btn-primary">Edit</a></td>
        <td><button  class="btn btn-primary abc" product =${element.productId}>Delete</button></td>
        
        <td>
            <a href="user.html"><i class="icon-pencil"></i></a>
            <a href="#myModal" role="button" data-toggle="modal"><i class="icon-remove"></i></a>
        </td>
      </tr>`);
      });
       console.log(result);
       $("button.abc").on("click", function (e) {
       const id =$(this).attr('product');
       $.ajax({
        url: "https://localhost:44357/api/products/del/"+id,
        type: "post",
        success: function (result) {
          console.log(result);
          location.href = "/products";
        },
        error: function (xhr, status, err) {
          console.log({xhr, status, err});
      if (err == "No conversion from text to application/json") location.href = "/products";
        },

      
      
      
      });
        
      });
    },
    
    error: function (xhr, status, err) {},

    


  });
 
  


});
