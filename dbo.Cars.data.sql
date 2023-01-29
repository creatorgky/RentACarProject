SET IDENTITY_INSERT [dbo].[Cars] ON
INSERT INTO [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (1, 1, 2, 2022, CAST(500000 AS Decimal(18, 0)), N'Ikinci el')
INSERT INTO [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (2, 1, 1, 2021, CAST(1000000 AS Decimal(18, 0)), N'Sifir')
INSERT INTO [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (3, 2, 2, 2020, CAST(750500 AS Decimal(18, 0)), N'Sifir')
INSERT INTO [dbo].[Cars] ([Id], [BrandId], [ColorId], [ModelYear], [DailyPrice], [Description]) VALUES (4, 2, 1, 2023, CAST(5000000 AS Decimal(18, 0)), N'Yeni Sifir')
SET IDENTITY_INSERT [dbo].[Cars] OFF
