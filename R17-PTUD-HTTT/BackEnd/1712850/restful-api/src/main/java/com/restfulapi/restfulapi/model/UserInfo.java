package com.restfulapi.restfulapi.model;


import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;

import javax.persistence.Table;

@Entity
@Table(name="userinfo")
public class UserInfo implements Serializable{
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name="userid",nullable = false,columnDefinition = "int")
	private Integer userId;
	
	@Column(name="username",nullable = true,columnDefinition = "nvarchar(50)")
	private String userName;

	@Column(name="userbirth",nullable = true,columnDefinition = "date")
	private Integer userBirth;

	@Column(name="usergender",nullable = true,columnDefinition = "int")
	private Integer userGender;

	@Column(name="userphone",nullable = true,columnDefinition = "varchar(20)")
	private String userPhone;
	
	@Column(name="userEmail",nullable = true,columnDefinition = "varchar(50)")
	private String useremail;

	@Column(name="useraddress",nullable = true,columnDefinition = "nvarchar(50)")
	private String userAddress;
	
	@Column(name="userArea",nullable = true,columnDefinition = "int")
	private Integer userArea;

	@Column(name="storeid",nullable = true,columnDefinition = "int")
	private Integer storeId;

	@Column(name="userloginname",nullable = true,columnDefinition = "varchar(50)")
	private String userLoginName;

	@Column(name="userpassword",nullable = true,columnDefinition = "varchar(50)")
	private String userPassword;

	public String getUserPassword() {
		return userPassword;
	}

	public void setUserPassword(String userPassword) {
		this.userPassword = userPassword;
	}

	public String getUserLoginName() {
		return userLoginName;
	}

	public void setUserLoginName(String userLoginName) {
		this.userLoginName = userLoginName;
	}

	public Integer getStoreId() {
		return storeId;
	}

	public void setStoreId(Integer storeId) {
		this.storeId = storeId;
	}

	public Integer getUserArea() {
		return userArea;
	}

	public void setUserArea(Integer userArea) {
		this.userArea = userArea;
	}

	public String getUserAddress() {
		return userAddress;
	}

	public void setUserAddress(String userAddress) {
		this.userAddress = userAddress;
	}

	public Integer getUserId() {
		return userId;
	}

	public void setUserId(Integer userId) {
		this.userId = userId;
	}

	public String getUserName() {
		return userName;
	}

	public void setUserName(String userName) {
		this.userName = userName;
	}

	public Integer getUserBirth() {
		return userBirth;
	}

	public void setUserBirth(Integer userBirth) {
		this.userBirth = userBirth;
	}

	public Integer getUserGender() {
		return userGender;
	}

	public void setUserGender(Integer userGender) {
		this.userGender = userGender;
	}

	public String getUserPhone() {
		return userPhone;
	}

	public void setUserPhone(String userPhone) {
		this.userPhone = userPhone;
	}

	public String getUseremail() {
		return useremail;
	}

	public void setUseremail(String useremail) {
		this.useremail = useremail;
	}
	
}
