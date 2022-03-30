package com.restfulapi.restfulapi.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.restfulapi.restfulapi.model.ProductType;
import com.restfulapi.restfulapi.repository.ProductTypeRepository;

@RestController
@RequestMapping("api/v1")
public class ProductTypeController {

	@Autowired
	private ProductTypeRepository ProductTypeRepository;
	
	@GetMapping("producttype/{StoreId}")
	public List<ProductType> getAllProductType (@PathVariable Integer StoreId) {
		return ProductTypeRepository.getProductTypeByStore(StoreId);
	}

}
