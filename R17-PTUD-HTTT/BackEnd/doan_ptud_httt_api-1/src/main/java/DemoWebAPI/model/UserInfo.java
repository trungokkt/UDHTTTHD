package DemoWebAPI.model;

import javax.persistence.Entity;
import javax.persistence.Table;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToOne;

import java.util.Date;

import javax.persistence.Column;

@Entity
@Table(name="UserInfo")
public class UserInfo {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Column(name ="UserId", nullable = false, columnDefinition = "int")
	private int userId;
	@Column(name ="UserName", nullable = false)
	private String userName;
	@Column(name ="UserBirth", nullable = false)
	private Date userBirth;
	@Column(name ="UserGender", nullable = false)
	private int userGender;
	@Column(name ="UserPhone", nullable = false)
	private String userPhone;
	@Column(name ="UserEmail", nullable = false)
	private String userEmail;
	@Column(name ="UserAddress", nullable = false)
	private String userAddress;
	@Column(name ="UserArea", nullable = false)
	private int userArea;
	@Column(name ="UserLoginName", nullable = false)
	private String userLoginName;
	@Column(name ="UserPassword", nullable = false)
	private String userPassword;
	@Column(name ="UserImg", nullable = false)
	private String userImg;
	public int getUserId() {
		return userId;
	}
	public void setUserId(int userId) {
		this.userId = userId;
	}
	public String getUserName() {
		return userName;
	}
	public void setUserName(String userName) {
		this.userName = userName;
	}
	public Date getUserBirth() {
		return userBirth;
	}
	public void setUserBirth(Date userBirth) {
		this.userBirth = userBirth;
	}
	public int getUserGender() {
		return userGender;
	}
	public void setUserGender(int userGender) {
		this.userGender = userGender;
	}
	public String getUserPhone() {
		return userPhone;
	}
	public void setUserPhone(String userPhone) {
		this.userPhone = userPhone;
	}
	public String getUserEmail() {
		return userEmail;
	}
	public void setUserEmail(String userEmail) {
		this.userEmail = userEmail;
	}
	public String getUserAddress() {
		return userAddress;
	}
	public void setUserAddress(String userAddress) {
		this.userAddress = userAddress;
	}
	public int getUserArea() {
		return userArea;
	}
	public void setUserArea(int userArea) {
		this.userArea = userArea;
	}
	public String getUserLoginName() {
		return userLoginName;
	}
	public void setUserLoginName(String userLoginName) {
		this.userLoginName = userLoginName;
	}
	public String getUserPassword() {
		return userPassword;
	}
	public void setUserPassword(String userPassword) {
		this.userPassword = userPassword;
	}
	public String getUserImg() {
		return userImg;
	}
	public void setUserImg(String userImg) {
		this.userImg = userImg;
	}
	public UserInfo(int userId, String userName, Date userBirth, int userGender, String userPhone, String userEmail,
			String userAddress, int userArea, String userLoginName, String userPassword, String userImg) {
		super();
		this.userId = userId;
		this.userName = userName;
		this.userBirth = userBirth;
		this.userGender = userGender;
		this.userPhone = userPhone;
		this.userEmail = userEmail;
		this.userAddress = userAddress;
		this.userArea = userArea;
		this.userLoginName = userLoginName;
		this.userPassword = userPassword;
		this.userImg = userImg;
	}
	
	public UserInfo() {super();}
	
	
}
