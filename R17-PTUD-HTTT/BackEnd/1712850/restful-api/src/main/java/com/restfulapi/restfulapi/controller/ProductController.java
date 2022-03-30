package com.restfulapi.restfulapi.controller;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.domain.PageRequest;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.restfulapi.restfulapi.model.Product;
import com.restfulapi.restfulapi.repository.ProductRepository;
@RestController
@RequestMapping("api/v1")
public class ProductController {
	@Autowired
	private ProductRepository ProductRepository;
	
	@GetMapping("products")
	public List<Product> getAllProducts(
			@RequestParam(name = "sort", required = false, defaultValue = "DESC") String sort,
			@RequestParam(name = "ColumSort",defaultValue = "createdDate") String ColumSort,
			@RequestParam(name = "page", required = false, defaultValue = "0") Integer page,
			@RequestParam(name = "storeid", required = false) Integer StoreId) {
		if(StoreId != null) {
			return ProductRepository.findProductByStore(StoreId);
		}
		
		Sort sortable = null;
		if (sort.equals("ASC")) {
			sortable = Sort.by(ColumSort).ascending();
		}
		if (sort.equals("DESC")) {
		    sortable = Sort.by(ColumSort).descending();
		}
		Integer limit = 5;
		
		Pageable pageable = PageRequest.of(page, limit, sortable);
		return ProductRepository.findAllMore(pageable);
		}
		@GetMapping("products/{id}")
		public Optional<Product>  getProductDetail(@PathVariable int id) {
			return ProductRepository.findById(id);
		}
//	@GetMapping("productss")
//	public List<Product> getStoreNear(
//			@RequestParam(name = "StoreId", required = false, defaultValue = "1") Integer StoreId) {
//		return ProductRepository.findProductByStore(StoreId);
//	}
//	@GetMapping("productstest")
//	public List<Product> productstest(
//			@RequestParam(name = "StoreId", required = false, defaultValue = "996") String adress) {
//		return ProductRepository.findTopProductEachStore(adress);
//	}
}
