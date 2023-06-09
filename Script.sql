USE [KDTB_1JO]
GO
/****** Object:  Table [dbo].[Table_1]    Script Date: 2023-03-24 오후 5:47:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Table_1](
	[wefwefwef] [nchar](10) NULL,
	[eewer] [nchar](10) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_Authority]    Script Date: 2023-03-24 오후 5:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_Authority](
	[MAJORCODE] [varchar](20) NOT NULL,
 CONSTRAINT [PK_TB_Authority] PRIMARY KEY CLUSTERED 
(
	[MAJORCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_LogInOutRec]    Script Date: 2023-03-24 오후 5:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_LogInOutRec](
	[USERID] [varchar](20) NOT NULL,
	[SEQNO] [int] NOT NULL,
	[INDATE] [date] NOT NULL,
	[INOUTFLAG] [varchar](10) NULL,
	[MAKEDATE] [datetime] NULL,
	[MAKER] [varchar](20) NULL,
 CONSTRAINT [PK_TB_LoginRec] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC,
	[SEQNO] ASC,
	[INDATE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_MENULIST]    Script Date: 2023-03-24 오후 5:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_MENULIST](
	[MENU_ID] [varchar](10) NOT NULL,
	[PARENT_ID] [varchar](10) NULL,
	[MENU_KEY] [varchar](20) NULL,
	[MENU_NAME] [varchar](50) NULL,
	[AUTHORITY] [varchar](30) NULL,
 CONSTRAINT [PK_TB_MENULIST] PRIMARY KEY CLUSTERED 
(
	[MENU_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_Standard]    Script Date: 2023-03-24 오후 5:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_Standard](
	[MAJORCODE] [varchar](50) NOT NULL,
	[MINORCODE] [varchar](50) NOT NULL,
	[CODENAME] [varchar](50) NOT NULL,
	[MAKEDATE] [datetime] NULL,
	[MAKER] [varchar](20) NULL,
	[EDITDATE] [datetime] NULL,
	[EDITOR] [varchar](20) NULL,
	[AUTHORITY] [varchar](20) NULL,
 CONSTRAINT [PK_TB_Standard] PRIMARY KEY CLUSTERED 
(
	[MAJORCODE] ASC,
	[MINORCODE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_UserMaster]    Script Date: 2023-03-24 오후 5:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_UserMaster](
	[USERID] [varchar](20) NOT NULL,
	[PASSWORD] [varchar](30) NOT NULL,
	[USERNAME] [varchar](10) NOT NULL,
	[DEPARTMENT] [varchar](20) NULL,
	[POSITION] [varchar](20) NULL,
	[ADDRESS] [varchar](100) NULL,
	[PHONE_NUMBER] [varchar](13) NULL,
	[AUTHORITY] [varchar](10) NULL,
	[IMAGE] [image] NULL,
	[EMAIL] [varchar](30) NULL,
	[PASSWORD_FCNT] [varchar](50) NULL,
	[MAKEDATE] [datetime] NULL,
	[MAKER] [varchar](20) NULL,
	[EDITDATE] [datetime] NULL,
	[EDITOR] [varchar](20) NULL,
 CONSTRAINT [PK_TB_UserMaster] PRIMARY KEY CLUSTERED 
(
	[USERID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[D1_UserMaster]    Script Date: 2023-03-24 오후 5:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이마무라영재
-- Create date: 2023-03-16
-- Description:	유저마스터 삭제
-- =============================================
CREATE PROCEDURE [dbo].[D1_UserMaster]
	@USERID			 VARCHAR(10), -- ID
	@USERNAME		 VARCHAR(10), -- 이름

	@LANG           VARCHAR(10) = 'KO' ,
	@RS_CODE        VARCHAR(1)   OUTPUT,
	@RS_MSG         VARCHAR(100) OUTPUT

AS
BEGIN
	-- 작업장 마스터 데이터 삭제.
	DELETE TB_UserMaster
	WHERE USERID   = @USERID
	  AND USERNAME = @USERNAME

	SET @RS_CODE = 'S'
END
GO
/****** Object:  StoredProcedure [dbo].[I1_User_Registration]    Script Date: 2023-03-24 오후 5:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		김현승
-- Create date: 2023-03-16
-- Description:	사용자 정보 등록 
-- =============================================
CREATE PROCEDURE [dbo].[I1_User_Registration] 

	@USERID         VARCHAR(20),    -- 사용자 아이디
	@PASSWORD   	VARCHAR(20),    -- 사용자 비밀번호
	@USERNAME   	VARCHAR(20),	-- 사용자 명
	@DEPARTMENT 	VARCHAR(20),	-- 부서
	@POSITON    	VARCHAR(20),	-- 직책
	@ADDRESS    	VARCHAR(20),	-- 주소
	@PHONE_NUMBER	VARCHAR(13),	-- 휴대전화 번호
	@EMAIL      	VARCHAR(20),	-- 이메일
	@AUTHORITY  	VARCHAR(5),		-- 권한
	@MAKER          VARCHAR(10),    -- 등록자

	@LANG    VARCHAR(10) = 'KO',
	@RS_CODE VARCHAR(1)   OUTPUT,
	@RS_MSG  VARCHAR(100) OUTPUT


AS
BEGIN
	
	-- USER_MASTER 테이블의 ID값이랑 비교하여 있으면 1을 던져주고 리턴 없으면 인서트
	IF(SELECT COUNT(*) 
		FROM TB_UserMaster
		WHERE USERID = @USERID) = 1
	BEGIN
		SELECT @RS_MSG = '이미 등록된 사용자 ID입니다.'
		SELECT @RS_CODE = 'E'  
		RETURN; 

	END




	-- 변수 생성
	DECLARE @LD_NOWDATE DATETIME,   -- 사용자 정보 등록 일시
			@POSITON01 VARCHAR(10)

        SET @LD_NOWDATE = GETDATE()

	
	--직책 이름만 가져와서 포지션에 이름으로 표기(변수만들어서 변수에 넣어서 이걸 넣어줌)
	SELECT @POSITON01 = CODENAME
	  FROM TB_Standard
		WHERE MAJORCODE ='POSITION'
		  AND MINORCODE = '20007'
		INSERT INTO TB_UserMaster (USERID,	        PASSWORD,	USERNAME,	DEPARTMENT,	 POSITION,	ADDRESS,
								   PHONE_NUMBER,	AUTHORITY,	EMAIL,	    MAKEDATE,	 MAKER)

						   VALUES (@USERID,		    @PASSWORD,  @USERNAME,  @DEPARTMENT, @POSITON01,  @ADDRESS,
								   @PHONE_NUMBER,   @AUTHORITY, @EMAIL,	    @LD_NOWDATE, @MAKER ) 
		SET @RS_CODE = 'S';


 
END
GO
/****** Object:  StoredProcedure [dbo].[S1_LoginMaster]    Script Date: 2023-03-24 오후 5:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		김현승
-- Create date: 2023-03-14
-- Description:	로그인 성공 후 정보 값 조회
-- =============================================
CREATE PROCEDURE [dbo].[S1_LoginMaster]
	@UserId   VARCHAR(20),   -- 사용자 ID
	@Password VARCHAR(30),   -- 사용자 PW

	@LANG     VARCHAR(10) = 'KO',
	@RS_CODE  VARCHAR(1)   OUTPUT,
	@RS_MSG   VARCHAR(100) OUTPUT



AS
BEGIN



SELECT A.*,
	   B.CODENAME
	FROM TB_UserMaster A WITH(NOLOCK) JOIN TB_Standard B WITH(NOLOCK)
	                                    ON (B.MAJORCODE = 'DEPARTMENT' AND B.MINORCODE = A.Department)
   WHERE UserId   = @UserId 
     AND Password = @Password

     SET @RS_CODE = 'S' 	 

END

GO
/****** Object:  StoredProcedure [dbo].[S1_StandardMaster]    Script Date: 2023-03-24 오후 5:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		김현승
-- Create date: 2023-03-15
-- Description:	공통 기준 정보 조회
-- =============================================
CREATE PROCEDURE [dbo].[S1_StandardMaster]

	@MAJORCODE VARCHAR(20),   -- 메이저코드
	@MINORCODE VARCHAR(20),   -- 마이너코드


	@LANG	   VARCHAR(10)   = 'KO',
    @RS_CODE   VARCHAR(1)    OUTPUT,
    @RS_MSG    VARCHAR(100)  OUTPUT


AS
BEGIN

	SELECT MAJORCODE,
		   MINORCODE,
		   CODENAME,
		   AUTHORITY,
		   MAKEDATE,
		   MAKER,   
		   EDITDATE,
		   EDITOR  
	  FROM TB_Standard 
	 WHERE MAJORCODE LIKE '%' + @MAJORCODE
	   AND MINORCODE LIKE '%' + @MINORCODE
	   AND MINORCODE <> '$'


	   SET @RS_CODE = 'S';

END
GO
/****** Object:  StoredProcedure [dbo].[S1_TB_MENULIST_USER]    Script Date: 2023-03-24 오후 5:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이종원
-- Create date: 20230316
-- Description:	사용자 별 메뉴 조회
-- =============================================
CREATE PROCEDURE [dbo].[S1_TB_MENULIST_USER]
	@USERID		VARCHAR(20),  -- 사용자 아이디
	@USERAUTH   VARCHAR(10),  -- 사용자 권한
	            
	@LANG		VARCHAR(10) = 'KO',   -- 다국어
	@RS_CODE    VARCHAR(1)   OUTPUT,  -- SQL 결과
	@RS_MSG     VARCHAR(100) OUTPUT   -- SQL 메세지
AS
BEGIN
	IF @USERAUTH = ''
	BEGIN
		SET @USERAUTH = 'D'
	END

  SELECT MENU_ID     AS MENU_ID 
	    ,PARENT_ID   AS PARENT_ID
	    ,MENU_KEY	 AS MENU_KEY
	    ,MENU_NAME	 AS MENU_NAME
	    ,AUTHORITY	 AS AUTHORITY
   FROM  TB_MENULIST 
   WHERE CHARINDEX(@USERAUTH, AUTHORITY) <> 0
ORDER BY MENU_ID
END
GO
/****** Object:  StoredProcedure [dbo].[S1_USERINFO]    Script Date: 2023-03-24 오후 5:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이종원
-- Create date: 20230316
-- Description:	부서별 사용자 정보 조회
-- =============================================
CREATE PROCEDURE [dbo].[S1_USERINFO]
	
    @LANG     VARCHAR(10) = 'KO',  
    @RS_CODE  VARCHAR(1)   OUTPUT, 
    @RS_MSG   VARCHAR(100) OUTPUT
AS
BEGIN
	select MINORCODE + '[' + CODENAME + ']' AS CODE_ID
		  ,CODENAME                         AS GROUPS
		  ,''  AS MEMBERS
	  from TB_Standard
	 WHERE MAJORCODE = 'DEPARTMENT'
	   AND MINORCODE <> '$'
	 UNION ALL
	 SELECT B.MINORCODE + '[' + B.CODENAME + ']' AS CODE_ID
		   , ''                                  AS GROUPS
		   ,A.USERNAME + '[' + A.POSITION + ']' AS MEMBERS
	   FROM TB_UserMaster A JOIN TB_Standard B
							  ON A.DEPARTMENT = B.MINORCODE
	ORDER BY CODE_ID, MEMBERS


END
GO
/****** Object:  StoredProcedure [dbo].[S1_UserMaster]    Script Date: 2023-03-24 오후 5:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<1JO 이마무라영재>
-- Create date: <2023-03-14>
-- Description:	<유저마스터 조회>
-- =============================================
CREATE PROCEDURE [dbo].[S1_UserMaster]
	            @USERNAME                 VARCHAR(20),  -- 유저 이름
	            @DEPARTMENT               VARCHAR(20),  -- 부서명
	            @POSITION                 VARCHAR(20),  -- 직책
	            @STARTDATE				  VARCHAR(20),	-- 시작 일자
	            @ENDDATE				  VARCHAR(20),  -- 끝 일자
	            
	            
	            @LANG			              VARCHAR(10) = 'KO',   -- 다국어
	            @RS_CODE                      VARCHAR(1)   OUTPUT,  -- SQL 결과
	            @RS_MSG                       VARCHAR(100) OUTPUT   -- SQL 메세지
AS
BEGIN
	SELECT A.USERID					        AS   USERID,		                  --ID       
		   A.USERNAME     			        AS   USERNAME,                        --이름
		   B.CODENAME				        AS   DEPARTMENT,	                  --부서
		   A.POSITION  				        AS   POSITION,  	                  --직위
		   A.ADDRESS   				        AS   ADDRESS,   		              --주소
		   A.PHONE_NUMBER				    AS   PHONE_NUMBER,	                  --전화번호
		   A.AUTHORITY 				        AS   AUTHORITY, 		              --사전
		   A.MAKEDATE  				        AS   MAKEDATE,  		              --만든날짜
		   A.MAKER   					    AS   MAKER,   			              --등록자 
		   A.EDITDATE  				        AS   EDITDATE, 	  	                  --수정날짜
		   A.EDITOR							AS	 EDITOR						      --수정자			
		
	FROM   TB_UserMaster A JOIN TB_Standard B WITH(NOLOCK)
	                         ON A.DEPARTMENT = B.MINORCODE
	   
    WHERE  A.USERNAME		LIKE '%' + @USERNAME	+ '%'
      AND  A.DEPARTMENT		LIKE '%' + @DEPARTMENT  + '%'
	  AND  A.POSITION		LIKE '%' + @POSITION    + '%'
	  AND  CONVERT(DATE, A.MAKEDATE) BETWEEN @STARTDATE AND @ENDDATE
		

	SET @RS_CODE = 'S'
END
 

 SELECT * FROM TB_UserMaster
GO
/****** Object:  StoredProcedure [dbo].[S2_LOGINOUTRec]    Script Date: 2023-03-24 오후 5:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		김현승
-- Create date: 2023-03-15
-- Description:	로그인 이력 조회
-- =============================================
CREATE PROCEDURE [dbo].[S2_LOGINOUTRec]

	@USERID    VARCHAR(30),          -- 사용자 ID
	@INOUTFLAG VARCHAR(10),		     -- 로그인, 로그아웃 여부
	@STARTDATE VARCHAR(10),          -- 시작 일자
	@ENDDATE   VARCHAR(10),			 -- 끝 일자

    @LANG	   VARCHAR(10)   = 'KO',
    @RS_CODE   VARCHAR(1)    OUTPUT,
    @RS_MSG    VARCHAR(100)  OUTPUT




AS
BEGIN
	
	SELECT  A.USERID     AS USERID 
		   ,B.USERNAME   AS USERNAME
		   ,C.CODENAME   AS DEPARTMENT
		   ,B.POSITION   AS POSITION
		   ,A.SEQNO    	 AS SEQNO
		   ,A.INOUTFLAG	 AS INOUTFLAG
		   ,A.MAKEDATE 	 AS MAKEDATE
		   ,A.MAKER		 AS MAKER
	  FROM TB_LogInOutRec A JOIN TB_UserMaster B WITH(NOLOCK)
							  ON A.USERID = B.USERID
							JOIN TB_Standard C WITH(NOLOCK)
							  ON (C.MAJORCODE = 'DEPARTMENT' AND B.DEPARTMENT = C.MINORCODE)
							  
	 WHERE A.USERID  LIKE '%' + @USERID  + '%'
	   AND A.INDATE  BETWEEN @STARTDATE AND @ENDDATE
	   AND A.INOUTFLAG LIKE '%' + @INOUTFLAG
	ORDER BY MAKEDATE DESC;

	SET @RS_CODE = 'S';
END

GO
/****** Object:  StoredProcedure [dbo].[U1_LOGINOUTREC_LOGIN]    Script Date: 2023-03-24 오후 5:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		김현승
-- Create date: 2023-03-14
-- Description:	로그인 이력 테이블
-- =============================================
CREATE PROCEDURE [dbo].[U1_LOGINOUTREC_LOGIN]

	@UserId   VARCHAR(20), -- 사용자 ID
	@Password VARCHAR(20), -- 사용자 PW

    @LANG     VARCHAR(10) = 'KO',  
    @RS_CODE  VARCHAR(1)   OUTPUT, 
    @RS_MSG   VARCHAR(100) OUTPUT

AS
BEGIN

	IF(SELECT COUNT(*)
		 FROM TB_UserMaster 
	    WHERE UserId   = @UserId
		  AND Password = @Password)= 0
		BEGIN
			SET @RS_CODE = 'E'
			SET @RS_MSG  = '로그인 정보가 일치하지 않습니다.'
			RETURN;
		END

		-- 공통 변수
		DECLARE @LD_NOWDATE DATETIME     -- 일시
			   ,@LS_NOWDATE VARCHAR(10)  -- 일자
		
		SET @LD_NOWDATE = GETDATE();
		SET @LS_NOWDATE = CONVERT(VARCHAR,@LD_NOWDATE,23)

     		-- 2. 일자별 로그인 기록 순번 가져오기
     	DECLARE @LI_SeqNo INT 
			
		-- 일자별 MAX 로그인 기록 순번 가져오기
     	SELECT @LI_SeqNo = ISNULL(MAX(SeqNo),0) + 1		
			FROM TB_LogInOutRec 
			WHERE UserId   = @UserId
			  AND INDATE = @LS_NOWDATE

	INSERT INTO TB_LogInOutRec (UserId,  SeqNo,     INOUTFLAG, INDATE,      MAKEDATE,    MAKER)
			         VALUES (@UserId, @LI_SeqNo, 'IN',      @LS_NOWDATE, @LD_NOWDATE, @UserId )
	SET @RS_CODE = 'S'



END

GO
/****** Object:  StoredProcedure [dbo].[U1_UserMaster]    Script Date: 2023-03-24 오후 5:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<1JO 이마무라영재>
-- Create date: <2023-03-16>
-- Description:	<유저마스터 수정>
-- =============================================
CREATE PROCEDURE [dbo].[U1_UserMaster]
	@USERID		  VARCHAR(20),
	@USERNAME     VARCHAR(20),  -- 유저 이름
	@DEPARTMENT   VARCHAR(20),  -- 부서명
	@POSITION     VARCHAR(20),  -- 직책
	@ADDRESS	  VARCHAR(20),	-- 주소
	@PHONE_NUMBER VARCHAR(20),  -- 전화번호
	@WRITER		  VARCHAR(20),  -- 입력자
	            
	            
	@LANG		  VARCHAR(10) = 'KO',   -- 다국어
	@RS_CODE      VARCHAR(1)   OUTPUT,  -- SQL 결과
	@RS_MSG       VARCHAR(100) OUTPUT   -- SQL 메세지
AS
BEGIN
	-- 변수 생성
	DECLARE @LD_NOWDATE DATETIME   -- 사용자 정보 등록 일시
        SET @LD_NOWDATE = GETDATE()
	
	DECLARE @DEPTCODE VARCHAR(20)
	SELECT @DEPTCODE =  MINORCODE
	  FROM TB_Standard
	 WHERE MAJORCODE = 'DEPARTMENT'
	   AND CODENAME = @DEPARTMENT;

	-- 유저마스터 데이터 수정
	UPDATE TB_UserMaster
	SET USERNAME	 = @USERNAME,
		DEPARTMENT   = @DEPTCODE,
		POSITION     = @POSITION,
		ADDRESS      = @ADDRESS,
		PHONE_NUMBER = @PHONE_NUMBER,
		EDITOR		 = @WRITER,
		EDITDATE     = @LD_NOWDATE
  WHERE USERID       = @USERID
				  

	SET @RS_CODE = 'S'
END
 

GO
/****** Object:  StoredProcedure [dbo].[U2_LOGINOUTREC_LOGOUT]    Script Date: 2023-03-24 오후 5:47:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		이종원
-- Create date: 20230316
-- Description:	로그아웃 이력 기록
-- =============================================
CREATE PROCEDURE [dbo].[U2_LOGINOUTREC_LOGOUT]
	@UserId   VARCHAR(20), -- 사용자 ID


    @LANG     VARCHAR(10) = 'KO',  
    @RS_CODE  VARCHAR(1)   OUTPUT, 
    @RS_MSG   VARCHAR(100) OUTPUT
AS
BEGIN
	-- 공통 변수
		DECLARE @LD_NOWDATE DATETIME     -- 일시
			   ,@LS_NOWDATE VARCHAR(10)  -- 일자
		
		SET @LD_NOWDATE = GETDATE();
		SET @LS_NOWDATE = CONVERT(VARCHAR,@LD_NOWDATE,23)

     		-- 2. 일자별 로그인아웃 기록 순번 가져오기
     	DECLARE @LI_SeqNo INT 
			
		-- 일자별 MAX 로그인아웃 기록 순번 가져오기
     	SELECT @LI_SeqNo = ISNULL(MAX(SeqNo),0) + 1		
			FROM TB_LogInOutRec 
			WHERE UserId   = @UserId
			  AND INDATE = @LS_NOWDATE

	INSERT INTO TB_LogInOutRec (UserId,  SeqNo,  INOUTFLAG, INDATE,      MAKEDATE,    MAKER)
			         VALUES (@UserId, @LI_SeqNo, 'OUT',     @LS_NOWDATE, @LD_NOWDATE, @UserId )
	SET @RS_CODE = 'S'
END
GO
