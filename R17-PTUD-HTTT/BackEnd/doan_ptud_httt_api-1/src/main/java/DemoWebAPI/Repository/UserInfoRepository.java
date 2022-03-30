package DemoWebAPI.Repository;


import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.stereotype.Repository;

import DemoWebAPI.model.*;

@Repository
public interface UserInfoRepository extends JpaRepository<UserInfo, Integer>{

}
