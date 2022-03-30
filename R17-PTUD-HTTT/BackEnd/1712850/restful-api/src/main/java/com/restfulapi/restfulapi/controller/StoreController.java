package com.restfulapi.restfulapi.controller;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import com.restfulapi.restfulapi.model.Store;
import com.restfulapi.restfulapi.repository.StoreRepository;

@RestController
@RequestMapping("api/v1")
public class StoreController {
	@Autowired
	private StoreRepository StoreRepository;
	
	@GetMapping("stores")
	public List<Store> getAllStore(
		@RequestParam(name = "local", required = false, defaultValue = "Tân phú") String local) {
		return StoreRepository.findStoreInLocal(local);
	}
}
