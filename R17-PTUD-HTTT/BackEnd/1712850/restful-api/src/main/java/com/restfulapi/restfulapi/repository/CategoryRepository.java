package com.restfulapi.restfulapi.repository;


import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.restfulapi.restfulapi.model.Categories;

@Repository
public interface CategoryRepository extends JpaRepository<Categories,Integer> {
}
