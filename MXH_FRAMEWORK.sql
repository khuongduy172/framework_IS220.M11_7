create database MXH
go
use MXH
go
set dateformat dmy

/*
use NORTHWND 
go 
DROP DATABASE MXH
*/

create table User_MXH (
	id int IDENTITY(1,1) constraint PK_User_MXH primary key not null,
	username varchar(225) not null UNIQUE,
	user_password varchar(225) not null,
	email varchar(225) not null UNIQUE,
	phone varchar(20),
	first_name nvarchar(225) not null,
	last_name nvarchar(225) not null,
	avatar nvarchar(225),
	cover_image nvarchar(225),
	date_of_birth datetime not null,
	gender nvarchar(10) not null,
	is_deleted bit,
	delete_at datetime,
	create_at datetime,
)

create table Friend (
	user_id int,
	friend_id int,
	constraint PK_Friend primary key (user_id, friend_id),
)

create table Follow (
	user_id int,
	follower_id int,
	constraint PK_Follow primary key (user_id, follower_id),
)

create table Message_MXH (
	id int IDENTITY(1,1),
	sender_id int,
	receiver_id int,
	content ntext,
	create_at datetime,
	constraint PK_Message_MXH primary key(id, sender_id, receiver_id),
)

create table Status_MXH (
	id int IDENTITY(1,1) constraint PK_Status_MXH primary key,
	owner_id int,
	content ntext,
	create_at datetime,
	update_at datetime, 
)

create table Status_image (
	id_image nvarchar(255) constraint PK_Status_image primary key,
	status_id int,
)

create table React_status (
	status_id int,
	type_react nvarchar(100),
	user_id int,
	constraint PK_React_status primary key(status_id, user_id),
)

create table Comment_status (
	id int IDENTITY(1,1),
	status_id int,
	user_id int,
	content ntext,
	create_at datetime,
	update_at datetime,
	constraint PK_Comment_status primary key(id, status_id, user_id),
)

create table Page_MXH (
	id int IDENTITY(1,1) constraint PK_Page_MXH primary key,
	owner_id int,
	description_MXH nvarchar(225),
	name_page nvarchar(225),
	avatar nvarchar(225),
	cover_image nvarchar(225),
	create_at datetime,
	update_at datetime,
	is_deleted bit,
)

create table User_like_page (
	page_id int,
	user_id int,
	constraint PK_User_like_page primary key (page_id, user_id),
)

create table Page_post (
	 id int IDENTITY(1,1) constraint PK_Page_post primary key,
	 page_id int,
	 content ntext,
	 create_at datetime,
)

create table React_page_post (
	post_id int,
	type_react NVARCHAR(100),
	user_id int,
	CONSTRAINT PK_React_page_post PRIMARY KEY(post_id, user_id),
)

create table Comment_page_post (
	id int IDENTITY(1,1),
	post_id int,
	user_id int,
	content ntext,
	create_at datetime,
	update_at datetime,
	constraint PK_Comment_page_post primary key(id, post_id, user_id),
)

create table Page_post_image (
	id_image nvarchar(255) constraint PK_Page_post_image primary key,
	post_id int,
)

CREATE TABLE Notification_MXH (
	id int IDENTITY(1,1),
	fromUID int,
	toUID int,
	content ntext,
	type_noti int,
	postId int,
	create_at datetime,
	update_at datetime,
	CONSTRAINT PK_notification PRIMARY KEY (id),
)

ALTER TABLE Friend 
ADD CONSTRAINT FK_FR_USER FOREIGN KEY (user_id) REFERENCES User_MXH(id);
ALTER TABLE Friend 
ADD CONSTRAINT FK_USER_FR FOREIGN KEY (friend_id) REFERENCES User_MXH(id);

ALTER TABLE Follow 
ADD CONSTRAINT FK_FL_USER FOREIGN KEY (user_id) REFERENCES User_MXH(id);
ALTER TABLE Follow 
ADD CONSTRAINT FK_USER_FL FOREIGN KEY (follower_id) REFERENCES User_MXH(id);

ALTER TABLE Message_MXH
add constraint FK_Message_MXH_sender_id foreign key (sender_id) references User_MXH(id);
ALTER TABLE Message_MXH
add constraint FK_Message_MXH_receiver_id foreign key (receiver_id) references User_MXH(id);

ALTER TABLE Status_MXH
add  constraint FK_Status_owner_id foreign key (owner_id) references User_MXH(id);

ALTER TABLE Status_image
add  constraint FK_Status_image_status_id foreign key (status_id) references Status_MXH(id);

ALTER TABLE React_status 
add  constraint  FK_React_status_status_id foreign key (status_id) references Status_MXH(id);
ALTER TABLE React_status 
add constraint FK_React_status_userId foreign key (user_id) references User_MXH(id);

ALTER TABLE Comment_status 
add constraint FK_Comment_status_status_id foreign key (status_id) references Status_MXH(id);
ALTER TABLE Comment_status 
add constraint FK_Comment_status_userId foreign key (user_id) references User_MXH(id);

ALTER TABLE Page_MXH 
add constraint FK_Page_owner_id foreign key (owner_id) references User_MXH(id);

ALTER TABLE User_like_page 
add constraint FK_User_like_page_page_id foreign key (page_id) references Page_MXH(id);
ALTER TABLE User_like_page 
add constraint FK_User_like_page_userId foreign key (user_id) references User_MXH(id);

ALTER TABLE Page_post 
add constraint FK_Page_post_page_id foreign key (page_id) references Page_MXH(id);

ALTER TABLE React_page_post 
add constraint FK_Reate_page_post_post_id foreign key (post_id) references Page_post(id);
ALTER TABLE React_page_post 
add CONSTRAINT FK_user_react_page_post FOREIGN KEY (user_id) REFERENCES User_MXH(id);

ALTER TABLE Comment_page_post 
add constraint FK_Comment_page_post_post_id foreign key (post_id) references Page_post(id);
ALTER TABLE Comment_page_post 
add constraint FK_Comment_page_post_userId foreign key (user_id) references User_MXH(id);

ALTER TABLE Page_post_image 
add constraint FK_page_image_post_id foreign key (post_id) references Page_post(id);

ALTER TABLE Notification_MXH 
add CONSTRAINT FK_noti_user_send FOREIGN KEY (fromUID) REFERENCES User_MXH(id);
ALTER TABLE Notification_MXH 
add CONSTRAINT FK_noti_user_recieve FOREIGN KEY (toUID) REFERENCES User_MXH(id);