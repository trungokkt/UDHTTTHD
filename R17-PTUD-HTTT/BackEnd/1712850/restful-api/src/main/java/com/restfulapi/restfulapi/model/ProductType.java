package com.restfulapi.restfulapi.model;

import java.io.Serializable;
import java.util.HashSet;
import java.util.Set;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.FetchType;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.OneToMany;
import javax.persistence.OneToOne;
import javax.persistence.Table;

@Entity
@Table(name="producttype")
public class ProductType implements Serializable{
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name="Producttypeid",nullable = false,columnDefinition = "int")
	private Integer productTypeId;
	
	@Column(name="Producttypename",nullable = true,columnDefinition = "nvarchar(50)")
	private String productTypeName;

	@OneToOne
	@JoinColumn(name = "storeid")
	private Store Store;
	
	@OneToOne
	@JoinColumn(name = "categoryid")
	private Categories Categories;
	
	// key
	@OneToMany(fetch = FetchType.LAZY, mappedBy = "ProductType")
	private Set<Product> listProduct = new HashSet<Product>();
	
	// get set
	public Integer getProductTypeId() {
		return productTypeId;
	}

	public void setProductTypeId(Integer productTypeId) {
		this.productTypeId = productTypeId;
	}

	public String getProductTypeName() {
		return productTypeName;
	}

	public void setProductTypeName(String productTypeName) {
		this.productTypeName = productTypeName;
	}

	public Store getStore() {
		return Store;
	}

	public void setStore(Store store) {
		Store = store;
	}

	public Categories getCategory() {
		return Categories;
	}

	public void setCategory(Categories categories) {
		Categories = categories;
	}

}
