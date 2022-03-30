package com.restfulapi.restfulapi.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.restfulapi.restfulapi.model.Categories;
import com.restfulapi.restfulapi.repository.CategoryRepository;

@RestController
@RequestMapping("api/v1")
public class CategoryController {
	@Autowired
	private CategoryRepository CategoryRepository;
	
	@GetMapping("categories")
	public List<Categories> getAllProducts() {
		return CategoryRepository.findAll();
	}
}
