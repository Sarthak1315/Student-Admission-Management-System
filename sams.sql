CREATE TABLE `Colleges_list`(
    `c_id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Colleges_name` VARCHAR(255) NOT NULL,
    `d_id` BIGINT NOT NULL
);
CREATE TABLE `Student`(
    `Enroll_no` VARCHAR(255) NOT NULL,
    `R_id` BIGINT NOT NULL,
    `c_id` BIGINT NOT NULL,
    `User_name` VARCHAR(255) NOT NULL,
    `Password` VARCHAR(255) NOT NULL,
    `d_id` BIGINT NOT NULL,
    PRIMARY KEY(`Enroll_no`)
);
CREATE TABLE `Faculty`(
    `F_id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Faculty_name` BIGINT NOT NULL,
    `d_id` BIGINT NOT NULL,
    `course_code` BIGINT NOT NULL
);
CREATE TABLE `Merit_history`(
    `M_id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `category` VARCHAR(255) NOT NULL,
    `pr` BIGINT NOT NULL
);
CREATE TABLE `Fees_detail`(
    `fee_id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Enroll_no` BIGINT NOT NULL,
    `sem` BIGINT NOT NULL,
    `paid` BIGINT NOT NULL
);
CREATE TABLE `Course`(
    `course_code` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `Course_Name` VARCHAR(255) NOT NULL,
    `d_id` VARCHAR(255) NOT NULL,
    `Yearly_fees` BIGINT NOT NULL
);
CREATE TABLE `Admin_User`(
    `id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `User_name` VARCHAR(255) NOT NULL,
    `Password` VARCHAR(255) NOT NULL,
    `Role` VARCHAR(255) NOT NULL
);
CREATE TABLE `Department`(
    `d_id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `d_name` VARCHAR(255) NOT NULL,
    `Stream` BIGINT NOT NULL
);
CREATE TABLE `Registration`(
    `R_id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT PRIMARY KEY,
    `First_name` VARCHAR(255) NOT NULL,
    `Middle_name` VARCHAR(255) NOT NULL,
    `Last_name` VARCHAR(255) NOT NULL,
    `Gender` BIGINT NOT NULL,
    `mobile_number` BIGINT NOT NULL,
    `Email` VARCHAR(255) NOT NULL,
    `category` VARCHAR(255) NOT NULL,
    `Ssc_per` BIGINT NOT NULL,
    `Ssc_res_file` VARCHAR(255) NOT NULL,
    `Hsc_per` BIGINT NOT NULL,
    `Hsc_res_file` VARCHAR(255) NOT NULL,
    `stream` VARCHAR(255) NOT NULL COMMENT 'Science,commerce,arts,etc',
    `d_id` BIGINT NOT NULL,
    `Address` VARCHAR(255) NOT NULL,
    `status` VARCHAR(255) NOT NULL,
    `profile_img` VARCHAR(255) NOT NULL
);
ALTER TABLE
    `Registration` ADD UNIQUE `registration_mobile_number_unique`(`mobile_number`);
ALTER TABLE
    `Registration` ADD UNIQUE `registration_email_unique`(`Email`);
ALTER TABLE
    `Fees_detail` ADD CONSTRAINT `fees_detail_enroll_no_foreign` FOREIGN KEY(`Enroll_no`) REFERENCES `Student`(`Enroll_no`);
ALTER TABLE
    `Course` ADD CONSTRAINT `course_d_id_foreign` FOREIGN KEY(`d_id`) REFERENCES `Department`(`d_id`);
ALTER TABLE
    `Student` ADD CONSTRAINT `student_r_id_foreign` FOREIGN KEY(`R_id`) REFERENCES `Registration`(`R_id`);
ALTER TABLE
    `Student` ADD CONSTRAINT `student_d_id_foreign` FOREIGN KEY(`d_id`) REFERENCES `Department`(`d_id`);
ALTER TABLE
    `Faculty` ADD CONSTRAINT `faculty_course_code_foreign` FOREIGN KEY(`course_code`) REFERENCES `Course`(`course_code`);
ALTER TABLE
    `Student` ADD CONSTRAINT `student_c_id_foreign` FOREIGN KEY(`c_id`) REFERENCES `Colleges_list`(`c_id`);
ALTER TABLE
    `Faculty` ADD CONSTRAINT `faculty_d_id_foreign` FOREIGN KEY(`d_id`) REFERENCES `Department`(`d_id`);
ALTER TABLE
    `Registration` ADD CONSTRAINT `registration_d_id_foreign` FOREIGN KEY(`d_id`) REFERENCES `Department`(`d_id`);
ALTER TABLE
    `Colleges_list` ADD CONSTRAINT `colleges_list_d_id_foreign` FOREIGN KEY(`d_id`) REFERENCES `Department`(`d_id`);