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
import javax.persistence.OneToMany;
import javax.persistence.Table;


@Entity
@Table(name="Store")
public class Store implements Serializable{
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name="storeid",nullable = false,columnDefinition = "int")
	private Integer StoreId;
	
	@Column(name="storename",nullable = true,columnDefinition = "nvarchar(50)")
	private String StoreName;

	@Column(name="storeaddress",nullable = true,columnDefinition = "nvarchar(MAX)")
	private String StoreAddress;

	@Column(name="storephone",nullable = true,columnDefinition = "nvarchar(20)")
	private String StorePhone;

	@Column(name="storerate",nullable = true,columnDefinition = "int")
	private Integer StoreRate;

	@Column(name="storearea",nullable = true,columnDefinition = "int")
	private Integer StoreArea;

	@Column(name="Userid",nullable = true,columnDefinition = "int")
	private Integer UserId;
	
	@Column(name="Storelat",nullable = true,columnDefinition = "nvarchar(50)")
	private String StoreLat;

	@Column(name="Storelng",nullable = true,columnDefinition = "nvarchar(50)")
	private String StoreLng;
	
	@Column(name="Storeimg",nullable = true,columnDefinition = "nvarchar(MAX)")
	private String StoreImg;
	
	@OneToMany(fetch = FetchType.LAZY, mappedBy = "Store")
	private Set<ProductType> listProductType = new HashSet<ProductType>();
	
	public Integer getStoreId() {
		return StoreId;
	}

	public void setStoreId(Integer storeId) {
		StoreId = storeId;
	}

	public String getStoreName() {
		return StoreName;
	}

	public void setStoreName(String storeName) {
		StoreName = storeName;
	}

	public String getStorePhone() {
		return StorePhone;
	}

	public void setStorePhone(String storePhone) {
		StorePhone = storePhone;
	}

	public Integer getStoreArea() {
		return StoreArea;
	}

	public void setStoreArea(Integer storeArea) {
		StoreArea = storeArea;
	}

	public Integer getStoreRate() {
		return StoreRate;
	}

	public void setStoreRate(Integer storeRate) {
		StoreRate = storeRate;
	}

	public String getStoreAddress() {
		return StoreAddress;
	}

	public void setStoreAddress(String storeAddress) {
		StoreAddress = storeAddress;
	}

	public Integer getUserId() {
		return UserId;
	}

	public void setUserId(Integer userId) {
		UserId = userId;
	}

	public String getStoreLat() {
		return StoreLat;
	}

	public void setStoreLat(String storeLat) {
		StoreLat = storeLat;
	}

	public String getStoreLng() {
		return StoreLng;
	}

	public void setStoreLng(String storeLng) {
		StoreLng = storeLng;
	}

	public String getStoreImg() {
		return StoreImg;
	}

	public void setStoreImg(String storeImg) {
		StoreImg = storeImg;
	}


}
