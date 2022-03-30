package com.restfulapi.restfulapi.model;

import java.io.Serializable;
import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.OneToOne;
import javax.persistence.Table;


@Entity
@Table(name="Product")
public class Product implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name="productid",nullable = false,columnDefinition = "int")
	private Integer productId;
	
	@Column(name="productname",nullable = true,columnDefinition = "nvarchar(50)")
	private String productName;
	
	@Column(name="productdescription",nullable = true,columnDefinition = "nvarchar(50)")
	private String productDescription;
	
	@Column(name="productprice",nullable = true,columnDefinition = "int")
	private Integer productPrice;
	
	@Column(name="productinventory",nullable = true,columnDefinition = "int")
	private Integer productInventory;
	
	@Column(name="productunit")
	private String productUnit;

	@Column(name="createddate", nullable = true, columnDefinition = "datetime")
	private Date createdDate; 
	
	@Column(name="updateddate", nullable = true, columnDefinition = "datetime")
	private Date updatedDate; 
	
	@Column(name="productimage", nullable = true, columnDefinition = "nvarchar(MAX)")
	private String productImage; 
	
	@OneToOne
	@JoinColumn(name = "Producttypeid")
	private ProductType ProductType;
	
	public Integer getProductId() {
		return productId;
	}

	public void setProductId(Integer productId) {
		this.productId = productId;
	}

	public String getProductName() {
		return productName;
	}

	public void setProductName(String productName) {
		this.productName = productName;
	}

	public String getProductDescription() {
		return productDescription;
	}

	public void setProductDescription(String productDescription) {
		this.productDescription = productDescription;
	}

	public Integer getProductPrice() {
		return productPrice;
	}

	public void setProductPrice(Integer productPrice) {
		this.productPrice = productPrice;
	}

	public Integer getProductInventory() {
		return productInventory;
	}

	public void setProductInventory(Integer productInventory) {
		this.productInventory = productInventory;
	}

	public Date getCreatedDate() {
		return createdDate;
	}

	public void setCreatedDate(Date createdDate) {
		this.createdDate = createdDate;
	}

	public String getProductUnit() {
		return productUnit;
	}

	public void setProductUnit(String productUnit) {
		this.productUnit = productUnit;
	}

	public Date getUpdatedDate() {
		return updatedDate;
	}

	public void setUpdatedDate(Date updatedDate) {
		this.updatedDate = updatedDate;
	}

	public ProductType getProductType() {
		return ProductType;
	}

	public void setProductType(ProductType productType) {
		ProductType = productType;
	}

	public String getProductImage() {
		return productImage;
	}

	public void setProductImage(String productImage) {
		this.productImage = productImage;
	}
	
}