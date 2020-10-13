exec Check_db_Version 20

------------------------------------------PRODUCT FIX NUMBER 1--------------------------------------------------------------------
update Product
set ProductImage = '\Images\WorldOfWarcraftClassic\reputation\argent_dawn.png'
where ProductName = 'ARGENT DAWN REPUTATION BOOST'
------------------------------------------PRODUCT FIX NUMBER 2--------------------------------------------------------------------
update Product
set ProductImage = '\Images\WorldOfWarcraftClassic\dungeons\blackfathom-deeps.png'
where ProductName = 'BLACKFATHOM DEEPS (24-32)'
------------------------------------------PRODUCT FIX NUMBER 3--------------------------------------------------------------------
update Product
set ProductImage = '\Images\WorldOfWarcraftClassic\powerleveling\char_leveling.png'
where ProductName = 'CHARACTER LEVELING TO 60'
------------------------------------------PRODUCT FIX NUMBER 4--------------------------------------------------------------------
update Product
set ProductImage = '\Images\WorldOfWarcraftClassic\profession\alchemy.png'
where ProductName = 'CLASSIC ALCHEMY 300 SKILL BOOST'
------------------------------------------PRODUCT FIX NUMBER 5--------------------------------------------------------------------
update Product
set ProductImage = '\Images\WorldOfWarcraft\mounts\clutch_of_hali.png'
where ProductName = 'CLUTCH OF HA-LI'
------------------------------------------PRODUCT FIX NUMBER 6--------------------------------------------------------------------
update Product
set ProductImage = '\Images\WorldOfWarcraft\dungeons\custom_mythic_key.png'
where ProductName = 'Custom Mythic key'
------------------------------------------PRODUCT FIX NUMBER 7--------------------------------------------------------------------
update Product
set ProductImage = '\Images\WorldOfWarcraft\raid\glacial_tidestrorm.png'
where ProductName = 'Glacial tide strorm'
------------------------------------------PRODUCT FIX NUMBER 8--------------------------------------------------------------------
update Product
set ProductImage = '\Images\WorldOfWarcraft\dungeons\high_mythic_keys.png'
where ProductName = 'High mythic+ keys'
------------------------------------------PRODUCT FIX NUMBER 9--------------------------------------------------------------------
update Product
set ProductImage = '\Images\WorldOfWarcraft\powerleveling\MadWorld.png'
where ProductName = 'MAD WORLD ACHIEVEMENT'
------------------------------------------PRODUCT FIX NUMBER 10--------------------------------------------------------------------
update Product
set ProductImage = '\Images\WorldOfWarcraft\dungeons\mythic15x3.png'
where ProductName = 'Mythic +15 x3 package'
------------------------------------------PRODUCT FIX NUMBER 11--------------------------------------------------------------------
update Product
set ProductImage = '\Images\WorldOfWarcraft\raid\nzoth_heroic.png'
where ProductName = 'N’ZOTH HEROIC KILL'
------------------------------------------PRODUCT FIX NUMBER 12--------------------------------------------------------------------
update Product
set ProductImage = '\Images\WorldOfWarcraft\raid\nyalotha.png'
where ProductName = 'Ny’alotha 11/12 Heroic'
------------------------------------------PRODUCT FIX NUMBER 13--------------------------------------------------------------------
update Product
set ProductImage = '\Images\WorldOfWarcraft\raid\nyalotha12h.png'
where ProductName = 'Ny’alotha 12/12 Heroic'
------------------------------------------PRODUCT FIX NUMBER 14--------------------------------------------------------------------
update Product
set ProductImage = '\Images\WorldOfWarcraft\reputation\rajani_reputation.png'
where ProductName = 'RAJANI REPUTATION'
------------------------------------------PRODUCT FIX NUMBER 15--------------------------------------------------------------------
update Product
set ProductImage = '\Images\WorldOfWarcraft\essences\vision-of-perfection.png'
where ProductName = 'VISION OF PERFECTION ESSENCE'
------------------------------------------PRODUCT FIX NUMBER 16--------------------------------------------------------------------
update Product
set ProductImage = '\Images\WorldOfWarcraft\dungeons\weekly_best15.png'
where ProductName = 'Weekly Best +15 key 8.3'
------------------------------------------PRODUCT FIX NUMBER 17--------------------------------------------------------------------
update Product
set ProductImage = '\Images\WorldOfWarcraftClassic\mounts\winterspring_frostsaber.png'
where ProductName = 'WINTERSPRING FROSTSABER MOUNT ALLIANCE ONLY BOOST'


exec Update_db_Version 20