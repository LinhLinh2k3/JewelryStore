---- Tạo bảng ----
CREATE TABLE [dbo].[users]
(
	[userID] INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	[userFullName] NVARCHAR(50) NOT NULL,
	[username] VARCHAR(50) NOT NULL UNIQUE,
	[userEmail] VARCHAR(255) NOT NULL UNIQUE,
	[userPhone] VARCHAR(12) NOT NULL UNIQUE,
	[userPassword] NVARCHAR(MAX) NOT NULL,
	[userGender] INT NOT NULL,
	[userAvatar] VARCHAR(MAX) NULL,
	[userAddress] NVARCHAR(500) NULL DEFAULT NULL,
	[userBio] TEXT NULL DEFAULT NULL,
	[roleID] INT NOT NULL DEFAULT 0  -- 0: Khách hàng, 1: Admin
)

CREATE TABLE [dbo].[categories]
(
	[catID] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[catName] NVARCHAR(60) NOT NULL,
	[catLink] VARCHAR(150) NOT NULL UNIQUE
)

CREATE TABLE [dbo].[materials]
(
	[matID] INT NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[matName] NVARCHAR(60) NOT NULL,
	[matLink] VARCHAR(150) NOT NULL UNIQUE
)

CREATE TABLE [dbo].[products]
(
	[prodID] CHAR(13) NOT NULL PRIMARY KEY,
	[prodName] NVARCHAR(150) NOT NULL,
	[prodPrice] INT NOT NULL,
	[prodDesc] NVARCHAR(MAX) NOT NULL,
	[prodAmount] BIGINT NOT NULL,
	[prodLink] VARCHAR(MAX) NOT NULL,
	[prodRevImg] VARCHAR(MAX) NOT NULL,
	[prodImg1] VARCHAR(MAX) NULL,
	[prodImg2] VARCHAR(MAX) NULL,
	[prodImg3] VARCHAR(MAX) NULL,
	[prodImg4] VARCHAR(MAX) NULL,
	[catID] INT NOT NULL,
	[matID] INT NOT NULL,

	CONSTRAINT cat_prod FOREIGN KEY ([catID]) REFERENCES [dbo].[categories](catID),
	CONSTRAINT mat_prod FOREIGN KEY ([matID]) REFERENCES [dbo].[materials](matID)
)

CREATE TABLE [dbo].[cartItems]
(
	[cartID] INT NOT NULL,
	[prodID] CHAR(13) NOT NULL,
	[quantity] INT NOT NULL,

	CONSTRAINT pk_cart PRIMARY KEY([cartID], [prodID]),
	CONSTRAINT prod_cart FOREIGN KEY ([prodID]) REFERENCES [dbo].[products]([prodID])
)

---- Thêm dữ liệu vào bảng ----
INSERT INTO [dbo].[materials]
VALUES
	('Gold', 'gold-jewelry'),
	('Silver', 'silver-jewelry'),
	('Platinum', 'platinum-jewelry'),
	('10K Gold', '10K-gold'),
	('14K Gold', '14K-gold'),
	('18K Gold', '18K-gold'),
	('22K Gold', '22K-gold'),
	('24K Gold', '24K-gold')

INSERT INTO [dbo].[categories]
VALUES
	('Ring', 'ring'),
	('Chain', 'chain'),
	('Pendant', 'pendant'),
	('Earrings', 'earrings'),
	('Bangle', 'bangle'),
	('Bracelet', 'bracelet'),	
	('Charm', 'charm'),
	('Necklace', 'necklace'),
	('Braces', 'braces'),
	('Gold Fortune', 'gold-fortune')

INSERT INTO [dbo].[products]
VALUES
	--Nhẫn Bạc
	(N'SNXM00X060003', N'Nhẫn Bạc đính đá STYLE by PNJ Sunlover XM00X060003', 565000, N'Hãy khám phá và để những thiết kế rực rỡ đầy màu sắc của truyền cảm hứng cho bạn kể câu chuyện mang đậm chất riêng của mình một cách đầy thú vị. Sở hữu thiết kế độc đáo với những điểm nhấn đá đầy màu sắc lấp lánh, chiếc nhẫn bạc STYLE By PNJ sẽ tôn lên vẻ đẹp cá tính và tinh tế của nàng xinh.Với sản phẩm này, nàng có thể kết hợp với nhiều món trang sức hoặc phụ kiện khác nhau như dây cổ, lắc, vòng trong BST Sunlover để tạo nên một phong cách thời trang của riêng mình hoặc tặng cho những người mà mình yêu thương.', 100 , 'nhan-bac-dinh-da-style-by-pnj-sunlover-xm00x060003', 'https://cdn.pnj.io/images/detailed/168/sp-snxm00x060003-nhan-bac-dinh-da-cz-style-by-pnj-1.png', 'https://cdn.pnj.io/images/detailed/168/sp-snxm00x060003-nhan-bac-dinh-da-cz-style-by-pnj-2.png', 'https://cdn.pnj.io/images/detailed/168/sp-snxm00x060003-nhan-bac-dinh-da-cz-style-by-pnj-3.png', 'https://cdn.pnj.io/images/detailed/168/on-snxm00x060003-nhan-bac-dinh-da-cz-style-by-pnj-1.jpg', null, 1, 2),
	(N'SNZTXMW000015', N'Nhẫn Bạc đính đá STYLE By PNJ Feminine ZTXMW000015', 565000, N'Trọng lượng tham khảo:7.53phân \n Hàm lượng chất liệu:9300\nLoại đá chính:Sythetic\nMàu đá chính:Đỏ\nHình dạng đá:Tròn\nLoại đá phụ:Xoàn mỹ\nMàu đá phụ:Trắng\nSố viên đá chính:1viên\nSố viên đá phụ:14viên\nThương hiệu:STYLE BY PNJ\nCut (Giác cắt/ Hình dạng kim cương):Facet\nGiới tính:Nữ', 200, 'nhan-bac-dinh-da-style-by-pnj-feminine-ztxmw000015', 'https://cdn.pnj.io/images/detailed/156/snztxmw000015-nhan-bac-dinh-da-style-by-pnj-feminine-01.png', 'https://cdn.pnj.io/images/detailed/156/snztxmw000015-nhan-bac-dinh-da-style-by-pnj-feminine-02.png', 'https://cdn.pnj.io/images/detailed/156/snztxmw000015-nhan-bac-dinh-da-style-by-pnj-feminine-03.png', 'https://cdn.pnj.io/images/detailed/156/snztxmw000015-nhan-bac-dinh-da-style-by-pnj-feminine-04.jpg', null, 1, 2),
	(N'SNNHXMW000008', N'Nhẫn Bạc STYLE By PNJ Aura NHXMW000008', 485000, N'Trọng lượng tham khảo:4.76733phân\nLoại đá chính:Nhân tạo\nLoại đá phụ:Xoàn mỹ\nSố viên đá chính:1viên\nSố viên đá phụ:19viên\nBộ sưu tập:Aura\nThương hiệu:STYLE BY PNJ\nCut (Giác cắt/ Hình dạng kim cương):Cabochon\nGiới tính:Nữ\n', 300,'nhan-bac-pnjsilver-aura-nhxmw000008', 'https://cdn.pnj.io/images/detailed/71/snnhxmw000008-nhan-bac-pnjsilver-aura-nhxmw000008-01.png', 'https://cdn.pnj.io/images/detailed/71/snnhxmw000008-nhan-bac-pnjsilver-aura-nhxmw000008-02.png', 'https://cdn.pnj.io/images/detailed/71/snnhxmw000008-nhan-bac-pnjsilver-aura-nhxmw000008-03.png', 'https://cdn.pnj.io/images/detailed/71/snnhxmw000008-nhan-bac-pnjsilver-aura-nhxmw000008-04.jpg',null, 1,2),
	(N'SNXMXMW060031', N'Nhẫn bạc đính đá PNJSilver XMXMW060031', 795000, N'Trọng lượng tham khảo:13.09342phân\nHàm lượng chất liệu:9250\nLoại đá chính:Xoàn mỹ\nMàu đá chính:Trắng\nLoại đá phụ:Xoàn mỹ\nThương hiệu:PNJSilver\nGiới tính:Nữ', 250, 'nhan-bac-dinh-da-pnjsilver-xmxmw060031', 'https://cdn.pnj.io/images/detailed/119/snxmxmw060031-nhan-bac-dinh-da-pnjsilver-1.png', 'https://cdn.pnj.io/images/detailed/119/snxmxmw060031-nhan-bac-dinh-da-pnjsilver-2.png', 'https://cdn.pnj.io/images/detailed/119/snxmxmw060031-nhan-bac-dinh-da-pnjsilver-3.png', 'https://cdn.pnj.io/images/detailed/119/snxmxmw060031-nhan-bac-dinh-da-pnjsilver-4.jpg', 'https://cdn.pnj.io/images/detailed/119/snxmxmw060031-nhan-bac-dinh-da-pnjsilver-5.jpg', 1, 2),

	--Nhẫn Vàng
	(N'GNXMXMY007523', N'Nhẫn Vàng 10K đính đá ECZ STYLE By PNJ Nàng Thu XMXMY007523', 4478000, N'Trọng lượng tham khảo:8.40508phân\nHàm lượng chất liệu:4160\nLoại đá chính:Xoàn mỹ\nHình dạng đá:Trái tim\nLoại đá phụ:Xoàn mỹ\nSố viên đá chính:1viên\nSố viên đá phụ:14viên\nBộ sưu tập:Nàng Thu\nThương hiệu:STYLE BY PNJ\nCut (Giác cắt/ Hình dạng kim cương):Facet\nGiới tính:Nữ', 500, 'nhan-vang-10k-dinh-da-ecz-style-by-pnj-nang-thu-xmxmy007523', 'https://cdn.pnj.io/images/detailed/137/gnxmxmy007523-nhan-vang-10k-dinh-da-ecz-style-by-pnj-nang-thu-01.png','https://cdn.pnj.io/images/detailed/137/gnxmxmy007523-nhan-vang-10k-dinh-da-ecz-style-by-pnj-nang-thu-02.png','https://cdn.pnj.io/images/detailed/137/gnxmxmy007523-nhan-vang-10k-dinh-da-ecz-style-by-pnj-nang-thu-03.png', 'https://cdn.pnj.io/images/detailed/137/gnxmxmy007523-nhan-vang-10k-dinh-da-ecz-style-by-pnj-nang-thu-04.jpg', 'https://cdn.pnj.io/images/detailed/137/gnxmxmy007523-nhan-vang-10k-dinh-da-ecz-style-by-pnj-nang-thu-05.jpg', 1, 4),
	(N'GNZTZTX000004', N'Nhẫn Vàng 10K đính đá Synthetic STYLE By PNJ Feminine ZTZTX000004', 3718000, N'Trọng lượng tham khảo:7.27171phân\nHàm lượng chất liệu:4160\nLoại đá chính:Sythetic\nHình dạng đá:Tròn\nLoại đá phụ:Sythetic\nSố viên đá chính:1viên\nSố viên đá phụ:5viên\nThương hiệu:STYLE BY PNJ\nCut (Giác cắt/ Hình dạng kim cương):Facet\nGiới tính:Nữ', 300, 'nhan-vang-10k-dinh-da-synthetic-style-by-pnj-feminine-ztztx000004', 'https://cdn.pnj.io/images/detailed/156/gnztztx000004-nhan-vang-10k-dinh-da-synthetic-style-by-pnj-feminine.png', 'https://cdn.pnj.io/images/detailed/156/gnztztx000004-nhan-vang-10k-dinh-da-synthetic-style-by-pnj-feminine-01.png','https://cdn.pnj.io/images/detailed/156/gnztztx000004-nhan-vang-10k-dinh-da-synthetic-style-by-pnj-feminine-02.png', 'https://cdn.pnj.io/images/detailed/156/gnztztx000004-nhan-vang-10k-dinh-da-synthetic-style-by-pnj-feminine-03.jpg', 'https://cdn.pnj.io/images/detailed/156/gnztztx000004-nhan-vang-10k-dinh-da-synthetic-style-by-pnj-feminine-04.jpg', 1, 4),
	(N'GN0000Y000294', N'Nhẫn cưới Vàng 24K PNJ 0000Y000294', 5890101, N'Trọng lượng tham khảo:8.90636phân\nHàm lượng chất liệu:9990\nLoại đá chính:Không gắn đá\nLoại đá phụ:Không gắn đá\nThương hiệu:PNJ\nGiới tính:Nữ', 500, 'nhan-cuoi-vang-24k-pnj-0000y000294', 'https://cdn.pnj.io/images/detailed/170/sp-gn0000y000294-nhan-cuoi-vang-24k-pnj-1.png', 'https://cdn.pnj.io/images/detailed/170/sp-gn0000y000294-nhan-cuoi-vang-24k-pnj-2.png', 'https://cdn.pnj.io/images/detailed/170/sp-gn0000y000294-nhan-cuoi-vang-24k-pnj-3.png', 'https://cdn.pnj.io/images/detailed/171/on-gn0000y000294-nhan-cuoi-vang-24k-pnj-1.jpg', 'https://cdn.pnj.io/images/detailed/171/on-gn0000y000294-nhan-cuoi-vang-24k-pnj-2.jpg', 1, 8),
	(N'GNMOXMX000027', N'Nhẫn Vàng 14K đính đá Moon PNJ MOXMX000027', 8937000, N'Trọng lượng tham khảo:9.296phân\nHàm lượng chất liệu:5850\nLoại đá chính:Moon\nMàu đá chính:Hồng\nHình dạng đá:Tròn\nLoại đá phụ:Xoàn mỹ\nMàu đá phụ:Trắng\nSố viên đá chính:1viên\nSố viên đá phụ:12viên\nThương hiệu:PNJ\nCut (Giác cắt/ Hình dạng kim cương):Cabochon\nKích thước đá (tham khảo):10 x 10 ly', 300, 'nhan-vang-14k-dinh-da-moon-pnj-moxmx000027', 'https://cdn.pnj.io/images/detailed/132/gnmoxmx000027-nhan-vang-14k-dinh-da-moon-pnj-01.png', 'https://cdn.pnj.io/images/detailed/132/gnmoxmx000027-nhan-vang-14k-dinh-da-moon-pnj-02.png', 'https://cdn.pnj.io/images/detailed/132/gnmoxmx000027-nhan-vang-14k-dinh-da-moon-pnj-03.png', 'https://cdn.pnj.io/images/detailed/132/gnmoxmx000027-nhan-vang-14k-dinh-da-moon-pnj-04.jpg','https://cdn.pnj.io/images/detailed/132/gnmoxmx000027-nhan-vang-14k-dinh-da-moon-pnj-05.jpg', 1, 5),

	--Dây chuyển bạc
	(N'SD0000W060052', N'Dây chuyền Bạc PNJSilver 0000W060052',445000, N'Trọng lượng tham khảo:9.12185phân\nHàm lượng chất liệu:9250\nLoại đá chính:Không gắn đá\nLoại đá phụ:Không gắn đá\nThương hiệu:PNJSilver\nGiới tính:Unisex', 200, 'day-chuyen-bac-pnjsilver-0000w060052','https://cdn.pnj.io/images/detailed/124/sd0000w060052-day-chuyen-bac-pnjsilver-1.png', 'https://cdn.pnj.io/images/detailed/124/sd0000w060052-day-chuyen-bac-pnjsilver-2.png', 'https://cdn.pnj.io/images/detailed/124/sd0000w060052-day-chuyen-bac-pnjsilver-3.png','https://cdn.pnj.io/images/detailed/124/sd0000w060052-day-chuyen-bac-pnjsilver-4.jpg', 'https://cdn.pnj.io/images/detailed/124/sd0000w060052-day-chuyen-bac-pnjsilver-5.jpg',2,2),
	(N'SD0000K060012', N'Dây chuyền bạc PNJSilver dây tay lật đơn 0000K060012', 308000 , N'Trọng lượng tham khảo:6.01033phân\nHàm lượng chất liệu:9250\nLoại đá chính:Không gắn đá\nLoại đá phụ:Không gắn đá\nThương hiệu:PNJSilver\nGiới tính:Unisex', 1500, 'day-chuyen-bac-day-tay-lat-don-pnjsilver-08371000','https://cdn.pnj.io/images/detailed/37/sd0000k060012-day-chuyen-bac-pnjsilver-day-dan-lat-don-01.png','https://cdn.pnj.io/images/detailed/37/sd0000k060012-day-chuyen-bac-pnjsilver-day-dan-lat-don-02.png','https://cdn.pnj.io/images/detailed/37/sd0000k060012-day-chuyen-bac-pnjsilver-day-dan-lat-don-03.png', 'https://cdn.pnj.io/images/detailed/72/sd0000k060012-day-chuyen-bac-pnjsilver-day-dan-lat-don-04.jpg', null,5,1),
	(N'SD0000H060000', N'Dây chuyền bạc Ý PNJSilver xoắn hai màu 0000H060000', 836500 , N'Trọng lượng tham khảo:29.1phân\nHàm lượng chất liệu:9292\nLoại đá chính:Không gắn đá\nLoại đá phụ:Không gắngắn\nThương hiệu:PNJPNJSil\nGiới tính:Nữ', 250 ,'day-chuyen-bac-y-pnjsilver-xoan-hai-mau-0000h060000', 'https://cdn.pnj.io/images/detailed/82/sd0000h060000-day-chuyen-bac-y-pnjsilver-xoan-hai-mau-01.png','https://cdn.pnj.io/images/detailed/82/sd0000h060000-day-chuyen-bac-y-pnjsilver-xoan-hai-mau-02.png','https://cdn.pnj.io/images/detailed/82/sd0000h060000-day-chuyen-bac-y-pnjsilver-xoan-hai-mau-03.png','https://cdn.pnj.io/images/detailed/82/sd0000h060000-day-chuyen-bac-y-pnjsilver-xoan-hai-mau-04.jpg',null,2,2),
	(N'SD0000W000011', N'Dây chuyền Bạc PNJSilver 0000W000011', 495000 , N'Trọng lượng tham khảo:9.14544phân\nHàm lượng chất liệu:9300\nLoại đá chính:Không gắn đđ\nLoại đá pphụ: Không gắn đđ\nThương hiệu:PPNJSilve\nGiới tính:UUnisex', 300 , 'day-chuyen-bac-pnjsilver-0000w000011','https://cdn.pnj.io/images/detailed/115/sd0000w000011-day-chuyen-bac-pnjsilver-1.png','https://cdn.pnj.io/images/detailed/115/sd0000w000011-day-chuyen-bac-pnjsilver-2.png','https://cdn.pnj.io/images/detailed/115/sd0000w000011-day-chuyen-bac-pnjsilver-3.png','https://cdn.pnj.io/images/detailed/115/sd0000w000011-day-chuyen-bac-pnjsilver-3.png',null,2,2),

	--Dây chuyền vàng
	(N'GD0000C000043', N'Dây chuyền Vàng Ý 18K PNJ 0000C000043', 16751000 , N'Trọng lượng tham khảo:26.58758phân\nHàm lượng chất liệu:7500\nLoại đá chính:Không gắn đá\nLoại đá phụ:Không gắn đá\nThương hiệu:PNJ\nGiới tính:Unisex',205 ,'day-chuyen-vang-y-18k-pnj-0000c000043', 'https://cdn.pnj.io/images/detailed/167/sp-gd0000c000043-day-chuyen-vang-y-18k-pnj-1.png','https://cdn.pnj.io/images/detailed/167/sp-gd0000c000043-day-chuyen-vang-y-18k-pnj-2.png','https://cdn.pnj.io/images/detailed/167/sp-gd0000c000043-day-chuyen-vang-y-18k-pnj-3.png','https://cdn.pnj.io/images/detailed/167/on-gd0000c000043-day-chuyen-vang-y-18k-pnj-1.jpg','https://cdn.pnj.io/images/detailed/167/on-gd0000c000043-day-chuyen-vang-y-18k-pnj-2.jpg', 2,2),
	(N'GD0000Y000413', N'Dây chuyền Vàng 16K PNJ 0000Y000413',  4954000, N'Trọng lượng tham khảo:9.07304phân\nHàm lượng chất liệu:6680\nLoại đá chính:Không gắn đđ\nLoại đá phụ:Không gắn đá\nThương hiệu:PPN\nGiới tính:Nữ', 3500, 'day-chuyen-vang-16k-pnj-0000Y000413', 'https://cdn.pnj.io/images/detailed/142/gd0000y000413-day-chuyen-vang-16k-pnj-01.png','https://cdn.pnj.io/images/detailed/142/gd0000y000413-day-chuyen-vang-16k-pnj-02.png','https://cdn.pnj.io/images/detailed/142/gd0000y000413-day-chuyen-vang-16k-pnj-3.png','https://cdn.pnj.io/images/detailed/142/gd0000y000413-day-chuyen-vang-16k-pnj-4.jpg','https://cdn.pnj.io/images/detailed/142/gd0000y000413-day-chuyen-vang-16k-pnj-5.jpg', 2, 6),
	(N'GD0000W061237', N'Dây chuyền nam Vàng trắng Ý 18K PNJ 0000W061237', 28290000 , N'Trọng lượng tham khảo:41.95471phân\nHàm lượng chất liệu:7500\nLoại đá chính:Không gắn đá\nLoại đá phụ:Không gắn đđ\nThương hiệu:PPN\nGiới tính:Nam', 500 ,'day-chuyen-nam-vang-trang-y-18k-pnj-0000w061237','https://cdn.pnj.io/images/detailed/161/gd0000w061237-Day-chuyen-Vang-18K-PNJ-1.png','https://cdn.pnj.io/images/detailed/161/gd0000w061237-Day-chuyen-Vang-18K-PNJ-2.png','https://cdn.pnj.io/images/detailed/161/gd0000w061237-Day-chuyen-Vang-18K-PNJ-3.png','https://cdn.pnj.io/images/detailed/161/gd0000w061237-Day-chuyen-Vang-18K-PNJ-4.png','https://cdn.pnj.io/images/detailed/161/gd0000w061237-Day-chuyen-Vang-18K-PNJ-5.jpg', 2,6),
	(N'GD0000W000948', N'Dây chuyền Vàng trắng Ý 18K PNJ Unisex 0000W000948', 34991000 , N'Trọng lượng tham khảo:55.53991phân\nHàm lượng chất liệu:7500\nLoại đá chính:Không gắn đá\nLoại đá phụ:Không gắn đđ\nPhong cách:FFashio\nThương hiệu:PNJ\nGiới tính:UUnisex', 1200,  'day-chuyen-vang-trang-Y-18K-J Unisex 0000W000948','https://cdn.pnj.io/images/detailed/182/sp-GD0000W000948-day-chuyen-vang-trang-y-18k-pnj-1.png','https://cdn.pnj.io/images/detailed/182/sp-GD0000W000948-day-chuyen-vang-trang-y-18k-pnj-2.png','https://cdn.pnj.io/images/detailed/182/sp-GD0000W000948-day-chuyen-vang-trang-y-18k-pnj-3.png','https://cdn.pnj.io/images/detailed/182/on-GD0000W000948-day-chuyen-vang-trang-y-18k-pnj-1.jpg','https://cdn.pnj.io/images/detailed/182/on-GD0000W000948-day-chuyen-vang-trang-y-18k-pnj-2.jpg', 2, 6),

	--Charm
	('XMXMY00000771', N'Hạt Charm Vàng 18K đính đá CZ PNJ', 2980000, N'Trọng lượng tham khảo:4.05275phân \nHàm lượng chất liệu:7500 \nLoại đá chính: Xoàn mỹ \nHình dạng đá: Tròn \nLoại đá phụ: Xoàn mỹ \nSố viên đá chính: 12viên \nSố viên đá phụ: 32viên \nLoại charm: Charm xỏ \nThương hiệu: PNJ \nCut (Giác cắt/ Hình dạng kim cương): Facet \nGiới tính:Nữ', 100 , 'charm-vang-18k-dinh-da-cz-pnj-xmxmy000077', 'https://cdn.pnj.io/images/detailed/154/gixmxmy000077-hat-charm-vang-18k-dinh-da-cz-pnj-1.png', 'https://cdn.pnj.io/images/detailed/154/gixmxmy000077-hat-charm-vang-18k-dinh-da-cz-pnj-2.png', 'https://cdn.pnj.io/images/detailed/154/gixmxmy000077-hat-charm-vang-18k-dinh-da-cz-pnj-3.png', 'https://cdn.pnj.io/images/detailed/154/gixmxmy000077-hat-charm-vang-18k-dinh-da-cz-pnj-5.jpg', null, 7, 1),
	('ZTXMW00000066', N'Hạt Charm Vàng trắng 18K đính đá Synthetic PNJ', 2690000, N'Trọng lượng tham khảo: 3.66466phân \nHàm lượng chất liệu: 7500 \nLoại đá chính: Sythetic \nKích thước đá chính (tham khảo): 2.5ly \nMàu đá chính: Xanh duơng \nHình dạng đá:Tròn \nLoại đá phụ:Xoàn mỹ \Màu đá phụ: \Trắng \nSố viên đá chính:1viên \nSố viên đá phụ: 9viên \nLoại charm:Charm xỏ \nThương hiệu: PNJ \nCut (Giác cắt/ Hình dạng kim cương):Facet \nGiới tính:Nữ',300,'hat-charm-vang-trang-18k-dinh-da-synthetic-pnj-ztxmw000006','https://cdn.pnj.io/images/detailed/157/giztxmw000006-hat-charm-vang-trang-18k-dinh-da-cz-pnj-1.png','https://cdn.pnj.io/images/detailed/157/giztxmw000006-hat-charm-vang-trang-18k-dinh-da-cz-pnj-2.png','https://cdn.pnj.io/images/detailed/157/giztxmw000006-hat-charm-vang-trang-18k-dinh-da-cz-pnj-3.png', 'https://cdn.pnj.io/images/detailed/167/on-giztxmw000006-hat-charm-vang-trang-18k-dinh-da-synthetic-pnj-1.jpg',null,7,1),
	('XMXMW00160278', N'Hạt charm Bạc đính đá PNJSilver', 2580000, N'Trọng lượng tham khảo:6.23803phân \nHàm lượng chất liệu: 9250 \nLoại đá chính: Xoàn mỹ \nLoại đá phụ: Xoàn mỹ\nLoại charm: Charm xỏ \nThương hiệu: PNJSilver \nGiới tính: Nữ', 260 , 'hat-charm-bac-dinh-da-pnjsilver-xmxmw060278', 'https://cdn.pnj.io/images/detailed/120/gnddddw007931-nhan-kim-cuong-vang-trang-14k-pnj-01.png', 'https://cdn.pnj.io/images/detailed/129/sixmxmw060278-hat-charm-bac-dinh-da-pnjsilver-2.png', 'https://cdn.pnj.io/images/detailed/120/gnddddw007931-nhan-kim-cuong-vang-trang-14k-pnj-03.png', 'https://cdn.pnj.io/images/detailed/120/gnddddw007931-nhan-kim-cuong-vang-trang-14k-pnj-04.jpg', 'https://cdn.pnj.io/images/detailed/120/gnddddw007931-nhan-kim-cuong-vang-trang-14k-pnj-05.jpg', 7, 1),
	('ZTZTY06000412', N'Hạt charm xỏ DIY đính đá PNJSilver cung Song Tử', 450000, N'Trọng lượng tham khảo: 6.79661phân \nHàm lượng chất liệu: 9250 \nLoại đá chính: Sythetic \nMàu đá chính: Trắng \nLoại đá phụ: Sythetic \nMàu đá phụ:Trắng \nLoại charm:Charm xỏ \nThương hiệu: PNJSilver \nGiới tính:Nữ',190,'hat-charm-xo-diy-dinh-da-pnjsilver-cung-song-tu','https://cdn.pnj.io/images/detailed/86/siztzty060004-hat-charm-xo-diy-dinh-da-pnjsilver-cung-song-tu.png','https://cdn.pnj.io/images/detailed/86/siztzty060004-hat-charm-xo-diy-dinh-da-pnjsilver-cung-song-tu-1.png','https://cdn.pnj.io/images/detailed/86/siztzty060004-hat-charm-xo-diy-dinh-da-pnjsilver-cung-song-tu-2.png','https://cdn.pnj.io/images/detailed/86/siztzty060004-hat-charm-xo-diy-dinh-da-pnjsilver-cung-song-tu-3.jpg', null,7,2),
	('GNPTDDW000100', N'Nhẫn Vàng trắng 14K đính Ngọc trai Tahiti PNJ', 22569000, N'Với gam màu đen tự nhiên, sở hữu độ ánh độc đáo, ngọc trai Tahiti nổi tiếng thế giới với vẻ đẹp và chất lượng ngọc tuyệt hảo được giới thượng lưu và người nổi tiếng yêu thích. Cùng với thiết kế thời thượng trên chất liệu vàng 14K tinh xảo và những viên kim cương nhỏ xinh, chiếc nhẫn ngọc trai Tahiti từ PNJ không chỉ là phụ kiện tôn lên vẻ đẹp sang trọng, quý phái mà còn giúp thể hiến đẳng cấp và vị thế.',90,'nhan-vang-trang-14k-dinh-ngoc-trai-tahiti-pnj-ptddw000100','https://cdn.pnj.io/images/detailed/97/gnptddw000100-nhan-vang-trang-14k-dinh-ngoc-trai-tahiti-pnj-01.png','https://cdn.pnj.io/images/detailed/97/gnptddw000100-nhan-vang-trang-14k-dinh-ngoc-trai-tahiti-pnj-02.png','https://cdn.pnj.io/images/detailed/97/gnptddw000100-nhan-vang-trang-14k-dinh-ngoc-trai-tahiti-pnj-03.png','https://cdn.pnj.io/images/detailed/97/gnptddw000100-nhan-vang-trang-14k-dinh-ngoc-trai-tahiti-pnj-04.jpg', null,1,1),
	('GN0000W001772', N'Nhẫn Vàng trắng Ý 18K đính đá PNJ 0000W001772', 5040000, N'Ngoài các loại vàng 10K, 14K hay 18K thì vàng Ý 18K cũng đang được nhiều người ưa chuộng bởi đặc tính dễ chế tác và giá thành hợp lý. Chiếc nhẫn được sản xuất từ chất liệu vàng Ý 18K cùng điểm nhấn đá CZ lấp lánh trên từng chi tiết.',200,'nhan-vang-trang-y-18k-dinh-da-pnj-0000w001772','https://cdn.pnj.io/images/detailed/125/gn0000w001772-nhan-vang-trang-y-18k-dinh-da-pnj-1.png','https://cdn.pnj.io/images/detailed/125/gn0000w001772-nhan-vang-trang-y-18k-dinh-da-pnj-2.png','https://cdn.pnj.io/images/detailed/125/gn0000w001772-nhan-vang-trang-y-18k-dinh-da-pnj-4.jpg', null, null,1,6),
	('GNDDDDW007931', N'Nhẫn Kim cương Vàng trắng 14K Disney|PNJ DDDDW007931', 18062000, N'Kim cương vốn là món trang sức mang đến niềm kiêu hãnh và cảm hứng thời trang bất tận. Sở hữu riêng cho mình món trang sức kim cương chính là điều mà ai cũng mong muốn. Chiếc nhẫn được chế tác từ vàng 14K cùng điểm nhấn kim cương với 57 giác cắt chuẩn xác, tạo nên món trang sức đầy sự sang trọng và đẳng cấp.',150,'nhan-kim-cuong-vang-trang-14k-disneypnj','https://cdn.pnj.io/images/detailed/120/gnddddw007931-nhan-kim-cuong-vang-trang-14k-pnj-01.png','https://cdn.pnj.io/images/detailed/120/gnddddw007931-nhan-kim-cuong-vang-trang-14k-pnj-02.png','https://cdn.pnj.io/images/detailed/120/gnddddw007931-nhan-kim-cuong-vang-trang-14k-pnj-04.jpg', null, null,1,5)