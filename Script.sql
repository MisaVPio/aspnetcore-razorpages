create database dbLab;

use dblab;

create table produtos (
	ProdId int auto_increment primary key,
	nome varchar(100),
	preco decimal(10,2),
	categoria varchar(50)
);

insert into produtos (nome,preco,categoria) values
('Apple iPhone 14', 999.99, 'Smartphones'),
('Samsung Galaxy S23', 899.99, 'Smartphones'),
('Sony WH-1000XM4', 349.99, 'Headphones'),
('Dell XPS 13', 1299.99, 'Laptops'),
('Apple MacBook Air', 999.00, 'Laptops'),
('Nike Air Max 270', 149.99, 'Footwear'),
('Adidas Ultraboost', 179.99, 'Footwear'),
('Samsung QLED TV', 1199.99, 'Televisions'),
('Amazon Echo Dot', 49.99, 'Smart Home'),
('Google Nest Hub', 89.99, 'Smart Home'),
('Fitbit Charge 5', 149.95, 'Wearables'),
('Garmin Forerunner 245', 349.99, 'Wearables'),
('Canon EOS R6', 2499.00, 'Cameras'),
('Nikon Z50', 849.95, 'Cameras'),
('Sony A7 III', 1999.99, 'Cameras'),
('Bose SoundLink Revolve+', 299.99, 'Speakers'),
('Apple Watch Series 8', 399.00, 'Wearables'),
('Lenovo Yoga 7i', 899.99, 'Laptops'),
('Microsoft Surface Pro 8', 1099.00, 'Tablets'),
('iPad Pro 11"', 799.99, 'Tablets'),
('Samsung Galaxy Tab S8', 699.99, 'Tablets'),
('LG OLED C1', 1799.99, 'Televisions'),
('Oculus Quest 2', 299.99, 'Gaming'),
('Xbox Series X', 499.99, 'Gaming'),
('PlayStation 5', 499.99, 'Gaming'),
('Razer DeathAdder V2', 69.99, 'Gaming Accessories'),
('Logitech G502 HERO', 49.99, 'Gaming Accessories'),
('Corsair K100 RGB', 229.99, 'Gaming Accessories'),
('Apple AirPods Pro', 249.99, 'Headphones'),
('Jabra Elite 85t', 229.99, 'Headphones'),
('OnePlus 10 Pro', 899.99, 'Smartphones'),
('Xiaomi Mi 11', 749.99, 'Smartphones'),
('Huawei P50', 799.99, 'Smartphones'),
('Nikon D3500', 499.00, 'Cameras'),
('Canon PowerShot G7 X', 699.99, 'Cameras'),
('Samsung Galaxy Buds Pro', 199.99, 'Headphones'),
('Bose QuietComfort 35 II', 299.99, 'Headphones'),
('Asus ROG Zephyrus G14', 1499.99, 'Laptops'),
('Acer Swift 3', 649.00, 'Laptops'),
('HP Spectre x360', 1399.99, 'Laptops'),
('Seagate Portable SSD', 149.99, 'Storage'),
('WD My Passport', 109.99, 'Storage'),
('SanDisk Ultra USB', 29.99, 'Storage'),
('Philips Hue Starter Kit', 199.99, 'Smart Home'),
('TP-Link Kasa Smart Plug', 29.99, 'Smart Home'),
('Ring Video Doorbell', 99.99, 'Smart Home'),
('Bose Home Speaker 500', 399.99, 'Speakers'),
('Sonos One', 199.99, 'Speakers'),
('Anker Soundcore Mini', 39.99, 'Speakers'),
('Google Pixel 7', 599.99, 'Smartphones'),
('Samsung Galaxy A54', 399.99, 'Smartphones'),
('Sony WH-CH710N', 199.99, 'Headphones'),
('Fitbit Versa 3', 229.95, 'Wearables'),
('Garmin Fenix 7', 799.99, 'Wearables'),
('Lenovo ThinkPad X1 Carbon', 1399.00, 'Laptops'),
('Apple iMac 24"', 1299.00, 'Desktops'),
('HP Envy Desktop', 999.99, 'Desktops'),
('Dell Alienware Aurora R14', 1799.99, 'Gaming PCs'),
('Razer Blade 15', 1999.99, 'Gaming Laptops'),
('MSI GE76 Raider', 2299.99, 'Gaming Laptops'),
('TCL 6-Series TV', 899.99, 'Televisions'),
('Sony A80J OLED', 1799.99, 'Televisions'),
('Philips 4K UHD TV', 599.99, 'Televisions'),
('Apple Pencil (2nd Gen)', 129.99, 'Tablets'),
('Samsung Galaxy S Pen', 39.99, 'Tablets'),
('Logitech MX Master 3', 99.99, 'Computer Accessories'),
('Razer Huntsman Elite', 199.99, 'Gaming Accessories'),
('ZOTAC GAMING GeForce RTX 3060', 499.99, 'Computer Hardware'),
('Corsair Vengeance LPX 16GB', 89.99, 'Computer Hardware'),
('Samsung 970 EVO NVMe SSD', 129.99, 'Storage'),
('Logitech C920 Webcam', 79.99, 'Computer Accessories'),
('Netgear Nighthawk Router', 199.99, 'Networking'),
('TP-Link Deco Mesh Wi-Fi', 149.99, 'Networking'),
('Ubiquiti UniFi AP', 99.99, 'Networking'),
('Sonos Beam Soundbar', 399.99, 'Speakers'),
('JBL Flip 6', 129.99, 'Speakers'),
('Anker Soundcore Life Q30', 89.99, 'Headphones'),
('Beats Studio3 Wireless', 349.95, 'Headphones'),
('Samsung Galaxy Watch 5', 329.99, 'Wearables'),
('Garmin Venu 2', 399.99, 'Wearables'),
('Dell UltraSharp Monitor', 599.99, 'Monitors'),
('ASUS ProArt Display', 499.99, 'Monitors'),
('LG UltraFine 5K', 1299.00, 'Monitors'),
('Apple Magic Keyboard', 99.99, 'Computer Accessories'),
('Logitech G Pro X Keyboard', 149.99, 'Gaming Accessories'),
('Seagate Game Drive for Xbox', 99.99, 'Gaming Accessories'),
('HyperX Cloud II Headset', 99.99, 'Gaming Accessories'),
('NVIDIA GeForce RTX 3090', 1499.99, 'Computer Hardware');


select * from produtos;

select categoria from produtos where categoria like 'Gaming Accessories';

select categoria, preco from produtos 

select distinct categoria from produtos 

select count(categoria) from produtos  

select * from produtos order by preco desc 

select * from produtos order by preco asc 

select * from produtos p order by ProdId desc 

select * from produtos p order by categoria asc , preco desc

select * from produtos p order by categoria desc , nome asc  

select * from produtos p where categoria ='televisions'

select * from produtos p where categoria = 'gaming accessories'

select * from produtos p where preco > '49,99'

select * from produtos p where preco > '500' 

select * from produtos p where categoria > 'gaming accessories' order by preco desc 

select * from produtos p where categoria < 'Monitors' order by categoria asc

select * from produtos p where categoria like '%accessories'

select * from produtos p where nome like 'logitech%'

select * from produtos p where nome like '%geforce%'

