package com.restfulapi.restfulapi.repository;

import java.util.List;


import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;

import com.restfulapi.restfulapi.model.Categories;
import com.restfulapi.restfulapi.model.ProductType;

@Repository
public interface ProductTypeRepository extends  JpaRepository<ProductType,Integer>{
	@Query("SELECT pt FROM ProductType pt")
	List<ProductType> getAllProductType();
	@Query("SELECT pt FROM Store st join st.listProductType pt where st.StoreId = :StoreId ")
	List<ProductType> getProductTypeByStore(Integer StoreId);
}