$(document).ready(function () {
    
    $("#my-form").submit((e) => {
      e.preventDefault();
      //POST
     
      
      $.ajax({
        url: "https://localhost:44357/api/Stores",
        type: "post",
        contentType:"application/json",
        dataType: "application/json",
        data: JSON.stringify({
          
            storeName: $("#StoreName").val(),
            storePhone: $("#StorePhone").val(),
            storeRate: parseInt($("#StoreRate").val(),10),
            storeArea:  parseInt($("#StoreArea").val(),10),
            userId:  parseInt($("#UserId").val(),10),
        }),
        success: function (result) {
         
          console.log(result);
         
        },
        
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
  
        
        error: function (xhr, status, err) {
          console.log({ xhr, status, err });
       // if (err == "No conversion from text to application/json") location.href = "/products";
          
          //alert(err);
        },
      });
      
     
      temp =  JSON.stringify({
          
        storeName: $("StoreName").val(),
        storePhone: $("StorePhone").val(),
        storeRate: parseInt($("#StoreRate").val(),10),
        storeArea:  parseInt($("#StoreArea").val(),10),
        userId:  parseInt($("#UserId").val(),10),
    }),
    console.log(temp);
    });
  });
  
