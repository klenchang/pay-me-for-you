CREATE TABLE IF NOT EXISTS `paymeforyou`.`user` (
  `id` int NOT NULL AUTO_INCREMENT,
  `user_name` varchar(30) NOT NULL,
  `merchant_id` int NOT NULL,
  `last_name` varchar(30) NOT NULL,
  `first_name` varchar(30) NOT NULL,
  `role_id` int NOT NULL,
  `last_login_time` timestamp(6) NULL DEFAULT NULL,
  `last_login_from` varchar(50) DEFAULT NULL,
  `status` tinyint NOT NULL,
  `password` varchar(30) NOT NULL,
  `ip_white_list` text,
  `Email` varchar(50),
  `Phone` varchar(20),
  `created_by` varchar(30) NOT NULL,
  `created_time` timestamp(6) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_user_merchant_idx` (`merchant_id`),
  KEY `fk_user_role_idx` (`role_id`),
  CONSTRAINT `fk_user_merchant` FOREIGN KEY (`merchant_id`) REFERENCES `merchant` (`id`),
  CONSTRAINT `fk_user_role` FOREIGN KEY (`role_id`) REFERENCES `role` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='user info';