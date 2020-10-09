exec Check_db_Version 10

update HtmlBlocksChildren
set Image = '/Images/Security.svg'
where Title = 'GUARANTEED SECURITY'
update HtmlBlocksChildren
set Image = '/Images/Service.svg'
where Title = 'HIGH QUALITY SERVICES'
update HtmlBlocksChildren
set Image = '/Images/Team.svg'
where Title = 'PROFESSIONAL TEAM'
update HtmlBlocksChildren
set Image = '/Images/Online.svg'
where Title = 'WE’RE ONLINE 24/7'

update HtmlBlocksChildren
set Image = '/Images/one.svg'
where Title = '1. Find the service you need'
update HtmlBlocksChildren
set Image = '/Images/two.svg'
where Title = '2. Place the order'
update HtmlBlocksChildren
set Image = '/Images/four.svg'
where Title = '3. We contact you in 5-10 mins'
update HtmlBlocksChildren
set Image = '/Images/five.svg'
where Title = '4. Boosting starts'
update HtmlBlocksChildren
set Image = '/Images/six.svg'
where Title = '5. Feedback'

update HtmlBlocksChildren
set Image = '/Images/we_are.svg'
where Title = 'WHO WE ARE'
update HtmlBlocksChildren
set Image = '/Images/80000.svg'
where Title = '80,000 SUCCESSFUL ORDERS'
update HtmlBlocksChildren
set Image = '/Images/our_team.svg'
where Title = 'OUR TEAM'
update HtmlBlocksChildren
set Image = '/Images/11_years.svg'
where Title = '11 YEARS ON THE MARKET'

exec Update_db_Version 10