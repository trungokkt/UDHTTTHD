package com.restfulapi.restfulapi.model;

import java.io.Serializable;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;
import javax.persistence.Table;

@Entity
@Table(name="Seller")
public class Seller implements Serializable{
	/**
	 * 
	 */
	private static final long serialVersionUID = 1L;
	@Id	
	@Column(name="Userid",nullable = false,columnDefinition = "int")
	private Integer UserId;
	
	public Integer getUserId() {
		return UserId;
	}
	public void setUserId(Integer userId) {
		UserId = userId;
	}
	
    //@OneToOne(mappedBy = "seller")
	//private UserInfo UserInfo;
}
