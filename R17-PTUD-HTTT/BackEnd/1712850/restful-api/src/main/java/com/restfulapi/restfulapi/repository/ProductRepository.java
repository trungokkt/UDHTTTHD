package com.restfulapi.restfulapi.repository;



import java.util.List;

import org.springframework.data.domain.Pageable;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.restfulapi.restfulapi.model.Product;



@Repository
public interface ProductRepository extends JpaRepository<Product,Integer>{
    @Query(value="SELECT p FROM Product p")
    public List<Product> findAllMore(Pageable pageable);
    @Query(value="SELECT p FROM Store st join st.listProductType pt join pt.listProduct p where st.StoreId = :StoreId")
    public List<Product> findProductByStore(Integer StoreId);
    @Query(value="SELECT DISTINCT(st.StoreId) FROM Store st join st.listProductType pt join pt.listProduct p where st.StoreAddress like %:adress%")
    public List<Product> findProductByAdress(String adress);
    
    @Query(value = "SELECT * FROM (\r\n"
    		+ "SELECT p.*,s.*,pt.ProductTypeName,\r\n"
    		+ "ROW_NUMBER() OVER (PARTITION BY s.StoreId Order by p.CreatedDate DESC) AS Sno#\r\n"
    		+ "FROM store s inner join producttype pt on s.storeid=pt.storeid inner join product p  on p.producttypeid=pt.producttypeid \r\n"
    		+ "WHERE s.StoreAddress like %:adress%\r\n"
    		+ ")pro\r\n"
    		+ "where Sno# < 2", nativeQuery = true)
    public List<Product> findTopProductEachStore(String adress);
}