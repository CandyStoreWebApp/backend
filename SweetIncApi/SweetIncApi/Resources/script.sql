USE [master]
GO
/****** Object:  Database [CandyStore]    Script Date: 11/22/2022 4:06:43 PM ******/
CREATE DATABASE [CandyStore]
GO
ALTER DATABASE [CandyStore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CandyStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CandyStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CandyStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CandyStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CandyStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CandyStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [CandyStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CandyStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CandyStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CandyStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CandyStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CandyStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CandyStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CandyStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CandyStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CandyStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CandyStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CandyStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CandyStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CandyStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CandyStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CandyStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CandyStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CandyStore] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CandyStore] SET  MULTI_USER 
GO
ALTER DATABASE [CandyStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CandyStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CandyStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CandyStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CandyStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CandyStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'CandyStore', N'ON'
GO
ALTER DATABASE [CandyStore] SET QUERY_STORE = OFF
GO
USE [CandyStore]
GO
/****** Object:  Table [dbo].[Box]    Script Date: 11/22/2022 4:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Box](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[quantity] [int] NULL,
	[lowerAge] [int] NULL,
	[upperAge] [int] NULL,
	[status] [bit] NOT NULL,
	[boxPatternId] [int] NULL,
 CONSTRAINT [PK_Box] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BoxPattern]    Script Date: 11/22/2022 4:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoxPattern](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](100) NOT NULL,
	[image] [nvarchar](500) NOT NULL,
	[status] [bit] NOT NULL,
	[price] [int] NOT NULL,
	[lowerAge] [int] NULL,
	[upperAge] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BoxProduct]    Script Date: 11/22/2022 4:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BoxProduct](
	[boxId] [int] NOT NULL,
	[productId] [int] NOT NULL,
	[quantity] [int] NOT NULL,
	[price] [int] NOT NULL,
	[productName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BoxProduct] PRIMARY KEY CLUSTERED 
(
	[boxId] ASC,
	[productId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Brand]    Script Date: 11/22/2022 4:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Brand](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[originId] [int] NOT NULL,
 CONSTRAINT [PK_Brand] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 11/22/2022 4:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Catagory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 11/22/2022 4:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[datetime] [datetime] NULL,
	[status] [int] NOT NULL,
	[paymentId] [int] NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 11/22/2022 4:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[orderId] [int] NOT NULL,
	[boxId] [int] NOT NULL,
	[price] [money] NULL,
	[quantity] [int] NULL,
 CONSTRAINT [PK_Orderdetail] PRIMARY KEY CLUSTERED 
(
	[orderId] ASC,
	[boxId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Origin]    Script Date: 11/22/2022 4:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Origin](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_origin] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PaymentDetail]    Script Date: 11/22/2022 4:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PaymentDetail](
	[id] [int] NOT NULL,
	[provider] [nvarchar](500) NOT NULL,
	[status] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 11/22/2022 4:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
	[quantity] [int] NOT NULL,
	[price] [money] NULL,
	[status] [bit] NULL,
	[image] [nvarchar](500) NOT NULL,
	[categoryId] [int] NOT NULL,
	[brandId] [int] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/22/2022 4:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NULL,
 CONSTRAINT [PK_role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 11/22/2022 4:06:43 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[email] [nvarchar](50) NULL,
	[username] [nvarchar](50) NULL,
	[password] [nvarchar](50) NULL,
	[fullname] [nvarchar](50) NULL,
	[roleId] [int] NULL,
	[status] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Box] ON 

INSERT [dbo].[Box] ([id], [quantity], [lowerAge], [upperAge], [status], [boxPatternId]) VALUES (1, 3, 10, 10, 0, 3)
INSERT [dbo].[Box] ([id], [quantity], [lowerAge], [upperAge], [status], [boxPatternId]) VALUES (5, 3, 30, 20, 1, 3)
INSERT [dbo].[Box] ([id], [quantity], [lowerAge], [upperAge], [status], [boxPatternId]) VALUES (6, 5, 30, 30, 1, 2)
INSERT [dbo].[Box] ([id], [quantity], [lowerAge], [upperAge], [status], [boxPatternId]) VALUES (8, 4, 30, 20, 1, 4)
INSERT [dbo].[Box] ([id], [quantity], [lowerAge], [upperAge], [status], [boxPatternId]) VALUES (9, 3, 40, 30, 1, 2)
INSERT [dbo].[Box] ([id], [quantity], [lowerAge], [upperAge], [status], [boxPatternId]) VALUES (10, 2, 40, 30, 1, 2)
INSERT [dbo].[Box] ([id], [quantity], [lowerAge], [upperAge], [status], [boxPatternId]) VALUES (11, 20, 40, 30, 1, 3)
INSERT [dbo].[Box] ([id], [quantity], [lowerAge], [upperAge], [status], [boxPatternId]) VALUES (12, 5, 20, 30, 1, 4)
INSERT [dbo].[Box] ([id], [quantity], [lowerAge], [upperAge], [status], [boxPatternId]) VALUES (1024, 5, 30, 20, 1, 4)
INSERT [dbo].[Box] ([id], [quantity], [lowerAge], [upperAge], [status], [boxPatternId]) VALUES (1025, 5, 30, 20, 1, 4)
INSERT [dbo].[Box] ([id], [quantity], [lowerAge], [upperAge], [status], [boxPatternId]) VALUES (1026, 3, 0, 0, 0, 2)
INSERT [dbo].[Box] ([id], [quantity], [lowerAge], [upperAge], [status], [boxPatternId]) VALUES (1027, 3, 0, 0, 0, 2)
INSERT [dbo].[Box] ([id], [quantity], [lowerAge], [upperAge], [status], [boxPatternId]) VALUES (1028, 3, 0, 0, 1, 2)
INSERT [dbo].[Box] ([id], [quantity], [lowerAge], [upperAge], [status], [boxPatternId]) VALUES (1030, 4, 0, 0, 1, 4)
SET IDENTITY_INSERT [dbo].[Box] OFF
GO
SET IDENTITY_INSERT [dbo].[BoxPattern] ON 

INSERT [dbo].[BoxPattern] ([id], [name], [image], [status], [price], [lowerAge], [upperAge]) VALUES (2, N'Wedding', N'Wedding Image', 1, 200, NULL, NULL)
INSERT [dbo].[BoxPattern] ([id], [name], [image], [status], [price], [lowerAge], [upperAge]) VALUES (3, N'Halloween', N'Halloween Image', 0, 300, NULL, NULL)
INSERT [dbo].[BoxPattern] ([id], [name], [image], [status], [price], [lowerAge], [upperAge]) VALUES (4, N'Christmas', N'Christmas Image', 0, 100, NULL, NULL)
INSERT [dbo].[BoxPattern] ([id], [name], [image], [status], [price], [lowerAge], [upperAge]) VALUES (6, N'Valentine', N'Valentine Image', 0, 250, NULL, NULL)
SET IDENTITY_INSERT [dbo].[BoxPattern] OFF
GO
INSERT [dbo].[BoxProduct] ([boxId], [productId], [quantity], [price], [productName]) VALUES (1, 1, 16, 0, N'')
INSERT [dbo].[BoxProduct] ([boxId], [productId], [quantity], [price], [productName]) VALUES (1, 2, 1, 0, N'')
INSERT [dbo].[BoxProduct] ([boxId], [productId], [quantity], [price], [productName]) VALUES (5, 1, 2, 0, N'')
INSERT [dbo].[BoxProduct] ([boxId], [productId], [quantity], [price], [productName]) VALUES (5, 2, 3, 0, N'')
INSERT [dbo].[BoxProduct] ([boxId], [productId], [quantity], [price], [productName]) VALUES (5, 4, 2, 0, N'')
INSERT [dbo].[BoxProduct] ([boxId], [productId], [quantity], [price], [productName]) VALUES (6, 1, 6, 0, N'')
INSERT [dbo].[BoxProduct] ([boxId], [productId], [quantity], [price], [productName]) VALUES (8, 4, 4, 0, N'')
INSERT [dbo].[BoxProduct] ([boxId], [productId], [quantity], [price], [productName]) VALUES (8, 6, 1, 0, N'')
INSERT [dbo].[BoxProduct] ([boxId], [productId], [quantity], [price], [productName]) VALUES (9, 1, 2, 0, N'')
INSERT [dbo].[BoxProduct] ([boxId], [productId], [quantity], [price], [productName]) VALUES (11, 1, 1, 0, N'')
INSERT [dbo].[BoxProduct] ([boxId], [productId], [quantity], [price], [productName]) VALUES (11, 2, 1, 0, N'')
INSERT [dbo].[BoxProduct] ([boxId], [productId], [quantity], [price], [productName]) VALUES (11, 3, 5, 0, N'')
INSERT [dbo].[BoxProduct] ([boxId], [productId], [quantity], [price], [productName]) VALUES (11, 4, 1, 0, N'')
INSERT [dbo].[BoxProduct] ([boxId], [productId], [quantity], [price], [productName]) VALUES (12, 2, 3, 0, N'')
INSERT [dbo].[BoxProduct] ([boxId], [productId], [quantity], [price], [productName]) VALUES (12, 3, 3, 0, N'')
GO
SET IDENTITY_INSERT [dbo].[Brand] ON 

INSERT [dbo].[Brand] ([id], [name], [originId]) VALUES (1, N'Hershey', 1)
INSERT [dbo].[Brand] ([id], [name], [originId]) VALUES (2, N'Giga Chad', 2)
INSERT [dbo].[Brand] ([id], [name], [originId]) VALUES (3, N'M&M''s', 3)
INSERT [dbo].[Brand] ([id], [name], [originId]) VALUES (5, N'Snickers', 1)
SET IDENTITY_INSERT [dbo].[Brand] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([id], [name]) VALUES (1, N'Wrapped Candy')
INSERT [dbo].[Category] ([id], [name]) VALUES (2, N'Unwrapped Candy')
INSERT [dbo].[Category] ([id], [name]) VALUES (3, N'Gummy')
INSERT [dbo].[Category] ([id], [name]) VALUES (4, N'Lolipop')
INSERT [dbo].[Category] ([id], [name]) VALUES (6, N'Mint')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([id], [userId], [datetime], [status], [paymentId]) VALUES (1, 3, CAST(N'2022-10-05T00:00:00.000' AS DateTime), 0, NULL)
INSERT [dbo].[Order] ([id], [userId], [datetime], [status], [paymentId]) VALUES (2, 3, CAST(N'2022-10-05T00:00:00.000' AS DateTime), 0, NULL)
INSERT [dbo].[Order] ([id], [userId], [datetime], [status], [paymentId]) VALUES (3, 4, CAST(N'2022-10-05T00:00:00.000' AS DateTime), 0, NULL)
INSERT [dbo].[Order] ([id], [userId], [datetime], [status], [paymentId]) VALUES (4, 3, CAST(N'2022-10-05T00:00:00.000' AS DateTime), 0, NULL)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
INSERT [dbo].[OrderDetail] ([orderId], [boxId], [price], [quantity]) VALUES (1, 1, 300.0000, 2)
INSERT [dbo].[OrderDetail] ([orderId], [boxId], [price], [quantity]) VALUES (1, 5, 200.0000, 1)
INSERT [dbo].[OrderDetail] ([orderId], [boxId], [price], [quantity]) VALUES (1, 6, 100.0000, 1)
INSERT [dbo].[OrderDetail] ([orderId], [boxId], [price], [quantity]) VALUES (2, 8, 200.0000, 1)
INSERT [dbo].[OrderDetail] ([orderId], [boxId], [price], [quantity]) VALUES (2, 9, 200.0000, 1)
INSERT [dbo].[OrderDetail] ([orderId], [boxId], [price], [quantity]) VALUES (3, 10, 100.0000, 1)
INSERT [dbo].[OrderDetail] ([orderId], [boxId], [price], [quantity]) VALUES (4, 11, 200.0000, 2)
INSERT [dbo].[OrderDetail] ([orderId], [boxId], [price], [quantity]) VALUES (4, 12, 300.0000, 2)
GO
SET IDENTITY_INSERT [dbo].[Origin] ON 

INSERT [dbo].[Origin] ([id], [name]) VALUES (1, N'NA')
INSERT [dbo].[Origin] ([id], [name]) VALUES (2, N'Canada')
INSERT [dbo].[Origin] ([id], [name]) VALUES (3, N'German')
INSERT [dbo].[Origin] ([id], [name]) VALUES (4, N'Dutch')
SET IDENTITY_INSERT [dbo].[Origin] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([id], [name], [quantity], [price], [status], [image], [categoryId], [brandId]) VALUES (1, N'Gourmet Salt Water Taffy - 5lb', 200, 20.9900, 1, N'https://cdn.shopify.com/s/files/1/0614/8309/0107/products/salt-water-taffy-bulk-assorted-tafy-town-candystore-470x470_1_1_180x.jpg?v=1647689533', 1, 1)
INSERT [dbo].[Product] ([id], [name], [quantity], [price], [status], [image], [categoryId], [brandId]) VALUES (2, N'Peppermint Starlight Mints - 7lb', 200, 18.9900, 1, N'https://cdn.shopify.com/s/files/1/0614/8309/0107/products/starlight-mints-peppermint-wmark_1_180x.jpg?v=1647672304', 6, 1)
INSERT [dbo].[Product] ([id], [name], [quantity], [price], [status], [image], [categoryId], [brandId]) VALUES (3, N'Andes Mints - 5lb', 200, 43.9900, 0, N'https://cdn.shopify.com/s/files/1/0614/8309/0107/products/andes-mints-5lbs_1_180x.jpg?v=1647667379', 6, 1)
INSERT [dbo].[Product] ([id], [name], [quantity], [price], [status], [image], [categoryId], [brandId]) VALUES (4, N'Haribo Gummi Gold Bears - 5lb', 200, 24.9900, 1, N'https://cdn.shopify.com/s/files/1/0614/8309/0107/products/haribo-gold-gummi-bears-02-wmark_180x.jpg?v=1649360898', 2, 2)
INSERT [dbo].[Product] ([id], [name], [quantity], [price], [status], [image], [categoryId], [brandId]) VALUES (5, N'Sour Patch Watermelon Slices - 5lb', 200, 25.9900, 1, N'https://cdn.shopify.com/s/files/1/0614/8309/0107/products/watermelon-slices-5lbs_2_180x.jpg?v=1647667165', 3, 2)
INSERT [dbo].[Product] ([id], [name], [quantity], [price], [status], [image], [categoryId], [brandId]) VALUES (6, N'Smarties Candy Rolls - 8lb Bulk', 200, 32.9900, 1, N'https://cdn.shopify.com/s/files/1/0614/8309/0107/products/smarties-bulk-wmark_180x.jpg?v=1647667248', 1, 1)
INSERT [dbo].[Product] ([id], [name], [quantity], [price], [status], [image], [categoryId], [brandId]) VALUES (7, N'Red Cherry Gummi Bears - 5lb', 200, 19.9900, 1, N'https://cdn.shopify.com/s/files/1/0614/8309/0107/products/cherry-gummi-bears-5lbs_1_180x.jpg?v=1647666293', 2, 3)
INSERT [dbo].[Product] ([id], [name], [quantity], [price], [status], [image], [categoryId], [brandId]) VALUES (9, N'Haribo Gummi Gold Bears Mini Bags - 54ct Tub', 200, 21.9900, 1, N'https://cdn.shopify.com/s/files/1/0614/8309/0107/products/hairbo-gold-bears-tub-04-wmark_180x.jpg?v=1647668754', 3, 3)
INSERT [dbo].[Product] ([id], [name], [quantity], [price], [status], [image], [categoryId], [brandId]) VALUES (10, N'Rainbow Whirly Pops 3" - 60ct', 200, 175.9900, 1, N'https://cdn.shopify.com/s/files/1/0614/8309/0107/products/rainbow-whirly-pops-3-60ct_2_180x.jpg?v=1647665992', 4, 2)
INSERT [dbo].[Product] ([id], [name], [quantity], [price], [status], [image], [categoryId], [brandId]) VALUES (11, N'Lolly Box Mega Double - 24ct', 200, 18.9900, 0, N'https://cdn.shopify.com/s/files/1/0614/8309/0107/products/lolly_box_mega_double_-_24ct_180x.jpg?v=1647676919', 4, 3)
INSERT [dbo].[Product] ([id], [name], [quantity], [price], [status], [image], [categoryId], [brandId]) VALUES (12, N'Giant Tootsie Pops - 72ct', 200, 27.9900, 1, N'https://cdn.shopify.com/s/files/1/0614/8309/0107/products/giant-tootsie-pops-72ct_180x.jpg?v=1647676693', 4, 1)
INSERT [dbo].[Product] ([id], [name], [quantity], [price], [status], [image], [categoryId], [brandId]) VALUES (13, N'Tootsie Pops - 100ct', 100, 56.9900, 1, N'https://cdn.shopify.com/s/files/1/0614/8309/0107/products/tootsie-pops-100ct_180x.gif?v=1647673257', 4, 2)
INSERT [dbo].[Product] ([id], [name], [quantity], [price], [status], [image], [categoryId], [brandId]) VALUES (14, N'Dubble Bubble Gum - 5lb', 200, 24.9900, 1, N'https://cdn.shopify.com/s/files/1/0614/8309/0107/products/dubble-bubble-original-bulk-icon_180x.jpg?v=1647667651', 1, 2)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([id], [name]) VALUES (1, N'Admin')
INSERT [dbo].[Role] ([id], [name]) VALUES (2, N'Customer')
INSERT [dbo].[Role] ([id], [name]) VALUES (3, N'Manager')
SET IDENTITY_INSERT [dbo].[Role] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [email], [username], [password], [fullname], [roleId], [status]) VALUES (1, N'admin1@mail.com', N'admin1', N'1', N'Admin 1', 1, 1)
INSERT [dbo].[User] ([id], [email], [username], [password], [fullname], [roleId], [status]) VALUES (2, N'admin2@mail.com', N'admin2', N'1', N'Admin 2', 1, 1)
INSERT [dbo].[User] ([id], [email], [username], [password], [fullname], [roleId], [status]) VALUES (3, N'user1@mail.com', N'user1', N'1', N'User 1', 2, 1)
INSERT [dbo].[User] ([id], [email], [username], [password], [fullname], [roleId], [status]) VALUES (4, N'user2@mail.com', N'user2', N'1', N'User 2', 2, 1)
INSERT [dbo].[User] ([id], [email], [username], [password], [fullname], [roleId], [status]) VALUES (5, N'admin2@mail.com', N'admin2', N'1', N'Admin 2', 1, 1)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Box] ADD  CONSTRAINT [status_notnull]  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[BoxPattern] ADD  DEFAULT ((1)) FOR [status]
GO
ALTER TABLE [dbo].[BoxPattern] ADD  DEFAULT ((100)) FOR [price]
GO
ALTER TABLE [dbo].[BoxProduct] ADD  CONSTRAINT [boxproduct_quantity]  DEFAULT ((0)) FOR [price]
GO
ALTER TABLE [dbo].[BoxProduct] ADD  CONSTRAINT [boxproduct_name]  DEFAULT ('') FOR [productName]
GO
ALTER TABLE [dbo].[Order] ADD  DEFAULT ('0') FOR [status]
GO
ALTER TABLE [dbo].[Box]  WITH CHECK ADD  CONSTRAINT [FK_Box_BoxPattern] FOREIGN KEY([boxPatternId])
REFERENCES [dbo].[BoxPattern] ([id])
GO
ALTER TABLE [dbo].[Box] CHECK CONSTRAINT [FK_Box_BoxPattern]
GO
ALTER TABLE [dbo].[BoxProduct]  WITH CHECK ADD  CONSTRAINT [FK_BoxProduct_Box] FOREIGN KEY([boxId])
REFERENCES [dbo].[Box] ([id])
GO
ALTER TABLE [dbo].[BoxProduct] CHECK CONSTRAINT [FK_BoxProduct_Box]
GO
ALTER TABLE [dbo].[BoxProduct]  WITH CHECK ADD  CONSTRAINT [FK_BoxProduct_Product] FOREIGN KEY([productId])
REFERENCES [dbo].[Product] ([id])
GO
ALTER TABLE [dbo].[BoxProduct] CHECK CONSTRAINT [FK_BoxProduct_Product]
GO
ALTER TABLE [dbo].[Brand]  WITH CHECK ADD  CONSTRAINT [FK_Brand_origin] FOREIGN KEY([originId])
REFERENCES [dbo].[Origin] ([id])
GO
ALTER TABLE [dbo].[Brand] CHECK CONSTRAINT [FK_Brand_origin]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD FOREIGN KEY([paymentId])
REFERENCES [dbo].[PaymentDetail] ([id])
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([userId])
REFERENCES [dbo].[User] ([id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_Orderdetail_Box] FOREIGN KEY([boxId])
REFERENCES [dbo].[Box] ([id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_Orderdetail_Box]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_Orderdetail_Order] FOREIGN KEY([orderId])
REFERENCES [dbo].[Order] ([id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_Orderdetail_Order]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Brand] FOREIGN KEY([brandId])
REFERENCES [dbo].[Brand] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Brand]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Catagory] FOREIGN KEY([categoryId])
REFERENCES [dbo].[Category] ([id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Catagory]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([roleId])
REFERENCES [dbo].[Role] ([id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [CandyStore] SET  READ_WRITE 
GO
