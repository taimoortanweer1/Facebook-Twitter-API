-- phpMyAdmin SQL Dump
-- version 4.0.4.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: May 23, 2014 at 07:06 PM
-- Server version: 5.6.11
-- PHP Version: 5.5.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `2pm`
--
CREATE DATABASE IF NOT EXISTS `2pm` DEFAULT CHARACTER SET latin1 COLLATE latin1_swedish_ci;
USE `2pm`;

-- --------------------------------------------------------

--
-- Table structure for table `alls`
--

CREATE TABLE IF NOT EXISTS `alls` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `item` varchar(200) NOT NULL,
  `title` varchar(200) NOT NULL,
  `link` varchar(200) NOT NULL,
  `snippet` varchar(300) NOT NULL,
  `senti_score` float DEFAULT NULL,
  `senti_type` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2616 ;

--
-- Dumping data for table `alls`
--

INSERT INTO `alls` (`id`, `item`, `title`, `link`, `snippet`, `senti_score`, `senti_type`) VALUES
(2606, '', '<b>Pakistan</b> - Wikipedia, the free encyclopedia', 'http://en.wikipedia.org/wiki/Pakistan', '', 0, 'positive'),
(2607, '', '<b>Pakistan</b> | World news | The Guardian', 'http://www.theguardian.com/world/pakistan', '', 0, 'positive'),
(2608, '', '<b>Pakistan</b>', 'http://www.pakistan.gov.pk/', '', 0, 'positive'),
(2609, '', '<b>Pakistan</b>: A Hard Country: Anatol Lieven: 9781610391450: Amazon <b>...</b>', 'http://www.amazon.com/Pakistan-Hard-Country-Anatol-Lieven/dp/1610391454', '', 0, 'positive'),
(2610, '', 'Country Guide: <b>PAKISTAN</b> (washingtonpost.com)', 'http://www.washingtonpost.com/wp-srv/world/countries/pakistan.html?nav=el', '', 0, 'positive'),
(2611, '', 'BBC News - <b>Pakistan</b> country profile', 'http://www.bbc.co.uk/news/world-south-asia-12965779', '', 0, 'positive'),
(2612, '', 'Country Study: <b>Pakistan</b>', 'http://lcweb2.loc.gov/frd/cs/pktoc.html', '', 0, 'positive'),
(2613, '', 'Welcome to <b>Pakistan</b>', 'http://www.tourism.gov.pk/', '', 0, 'positive'),
(2614, '', '<b>Pakistan</b>', 'https://www.cia.gov/library/publications/the-world-factbook/geos/pk.html', '', 0, 'positive'),
(2615, '', '<b>Pakistan</b> | Reuters.com', 'http://www.reuters.com/places/pakistan', '', 0, 'positive');

-- --------------------------------------------------------

--
-- Table structure for table `best`
--

CREATE TABLE IF NOT EXISTS `best` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `item` varchar(200) NOT NULL,
  `title` varchar(200) NOT NULL,
  `link` varchar(200) NOT NULL,
  `snippet` varchar(300) NOT NULL,
  `senti_score` float DEFAULT NULL,
  `senti_type` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `crawls`
--

CREATE TABLE IF NOT EXISTS `crawls` (
  `id` int(255) NOT NULL AUTO_INCREMENT,
  `search_key` varchar(100) NOT NULL,
  `p_url_1` varchar(200) NOT NULL,
  `depth` varchar(100) NOT NULL,
  `title` varchar(500) NOT NULL,
  `link` varchar(200) NOT NULL,
  `score` varchar(50) DEFAULT NULL,
  `senti_type` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `forbidden_urls`
--

CREATE TABLE IF NOT EXISTS `forbidden_urls` (
  `id` int(100) NOT NULL AUTO_INCREMENT,
  `link` varchar(200) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=2 ;

--
-- Dumping data for table `forbidden_urls`
--

INSERT INTO `forbidden_urls` (`id`, `link`) VALUES
(1, 'https://www.facebook.com/');

-- --------------------------------------------------------

--
-- Table structure for table `info`
--

CREATE TABLE IF NOT EXISTS `info` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `item` varchar(200) NOT NULL,
  `title` varchar(200) NOT NULL,
  `link` varchar(200) NOT NULL,
  `snippet` varchar(300) NOT NULL,
  `senti_score` float DEFAULT NULL,
  `senti_type` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;

-- --------------------------------------------------------

--
-- Table structure for table `seed`
--

CREATE TABLE IF NOT EXISTS `seed` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `link` varchar(1000) NOT NULL,
  `s_key` varchar(100) NOT NULL,
  `senti_type` varchar(30) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=239 ;

--
-- Dumping data for table `seed`
--

INSERT INTO `seed` (`id`, `link`, `s_key`, `senti_type`) VALUES
(236, 'http://www.nytimes.com/2013/11/02/world/asia/how-the-pakistani-taliban-became-a-deadly-force.html', 'tehrik taliban Pakistan', 'negative'),
(238, 'http://www.huffingtonpost.com/tag/tehrik-e-taliban-pakistan/', 'tehrik taliban Pakistan', 'negative');

-- --------------------------------------------------------

--
-- Table structure for table `stat`
--

CREATE TABLE IF NOT EXISTS `stat` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `item` varchar(200) NOT NULL,
  `title` varchar(200) NOT NULL,
  `link` varchar(200) NOT NULL,
  `snippet` varchar(300) NOT NULL,
  `senti_score` float DEFAULT NULL,
  `senti_type` varchar(20) DEFAULT NULL,
  `size` varchar(100) NOT NULL,
  `no_of_pos` varchar(100) NOT NULL,
  `no_of_neg` varchar(100) NOT NULL,
  `text` longtext NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `id` (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=4 ;

--
-- Dumping data for table `stat`
--

INSERT INTO `stat` (`id`, `item`, `title`, `link`, `snippet`, `senti_score`, `senti_type`, `size`, `no_of_pos`, `no_of_neg`, `text`) VALUES
(1, '', '<b>Winter</b> (dolphin) - Wikipedia, the free encyclopedia', 'http://en.wikipedia.org/wiki/Winter_(dolphin)', '', 0.0253298, 'positive', '-1', '', '', ''),
(2, '', '<b>Winter</b> - Wikipedia, the free encyclopedia', 'http://en.wikipedia.org/wiki/Winter', '', -0.029516, 'negative', '-1', '', '', ''),
(3, '', '<b>Winter</b>: Notes from Montana: Rick Bass: 0046442611503: Amazon <b>...</b>', 'http://www.amazon.com/Winter-Notes-Montana-Rick-Bass/dp/0395611504', '', 0.134314, 'positive', '-1', '', '', '');

-- --------------------------------------------------------

--
-- Table structure for table `tweets`
--

CREATE TABLE IF NOT EXISTS `tweets` (
  `user` varchar(100) NOT NULL,
  `tweet` varchar(600) NOT NULL,
  `senti_type` varchar(20) NOT NULL,
  `senti_score` float DEFAULT NULL,
  `keyword` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tweets`
--

INSERT INTO `tweets` (`user`, `tweet`, `senti_type`, `senti_score`, `keyword`) VALUES
('Sheis_Undefined', 'â€œ@laylowbang: @Sheis_Undefined beefâ€why bruh lol', 'positive', NULL, 'undefined'),
('_Undefined_x3', 'RT @WW1DAlerts: If these are peoples reactions to the story of my life music video what''s going to be ours??! http://t.co/G0zG3yn55S', 'neutral', NULL, 'undefined'),
('1Deep_Undefined', 'RT @HustleConstant: Motherfuckers made me the way I am.', 'neutral', NULL, 'undefined'),
('_MarciaaaxO', '@_Undefined_x3 aw I wish I could go today but I can''t since I didn''t go to school, good luck though!', 'positive', NULL, 'undefined'),
('Undefined_Britt', 'Then wanted 2 talk afterwards... um noo goodbye! !!!!!', 'neutral', NULL, 'undefined'),
('Ryannnnn___', 'RT @Rezon_DaDawn: s/o to @undefined_roses , &amp; @Ryannnnn___  . #ADORE', 'positive', NULL, 'undefined'),
('Undefined_Britt', 'Killed my vibe!!!', 'negative', NULL, 'undefined'),
('HumanitiesAll', 'Oppose cuts to NEH! Send a message to Congress today!\nhttp://t.co/LXKiHZsTDM', 'negative', NULL, 'undefined'),
('_Undefined_x3', 'RT @stylesagram: HARRY CRIED BECAUSE IT WAS THE LAST TAKE ME HOME TOUR CONCERT NOW I''M CRYING http://t.co/IGk6v2K4Vz', 'negative', NULL, 'undefined'),
('Undefined_Britt', 'My moms st8 pissed me off! !!', 'negative', NULL, 'undefined'),
('FriendOfABadMan', 'Photo: youngjusticer: Lobo is an interstellar mercenary. He possesses extraordinary strength of undefined... http://t.co/7eZsfLYvKW', 'negative', NULL, 'undefined'),
('_Undefined_x3', 'RT @_MarciaaaxO: @_Undefined_x3 aw today is your last volleyball game', 'negative', NULL, 'undefined'),
('u_s_f_m_e_p', 'RT @WomenforWomen: Did you know: 10 Facts About Girl''s Education. @GirlRising http://t.co/Tstvgl30mq', 'neutral', NULL, 'undefined'),
('_Undefined_x3', '@_MarciaaaxO Yes unfortunately :(', 'negative', NULL, 'undefined'),
('_Undefined_x3', 'RT @Ranked_Random: waiting for the music video to come out with @_Undefined_x3 and @Nicole_G_xox   I can''t wait any longer!!', 'neutral', NULL, 'undefined'),
('undefined__Xo', '@jchildssss okayy babe î˜', 'neutral', NULL, 'undefined'),
('Undefined_Odera', '@F_ckThatHoe now. when i talk to you later. and ask you that question. i best have a answer bestfriend.!', 'positive', NULL, 'undefined'),
('74_SHENKO', '@Sheis_Undefined FOOL NOT FINNA DO NOTHING TO YU BIG BOOTY .', 'negative', NULL, 'undefined'),
('TheNHattonBand', 'undefined has a new Fan Questions Widget. Ask a question now! http://t.co/QaIK6tn22d via @FanBridge', 'negative', NULL, 'undefined'),
('liljaarn', 'RT @WomenforWomen: Did you know: 10 Facts About Girl''s Education. @GirlRising http://t.co/Tstvgl30mq', 'neutral', NULL, 'undefined'),
('DISCAwards', 'RT @WashArchdiocese: Praying for those who lost their lives in service to others. #BlueMass http://t.co/9ZcmnPUEuR', 'negative', -0.123354, 'lost'),
('smail_sandi', 'RT @RonanDaily: Today: the heartbreaking story of Nigeriaâ€™s lost girls and the LA director whose rallying cry inspired #BringBackOurGirls mâ€¦', 'negative', -0.606795, 'lost'),
('lolliput', 'Workout in progress and my appetite has been lost now yeaaay otw kurusðŸ’ª', 'neutral', 0, 'lost'),
('_FreeKB_', 'Your message could get lost in a flurry of too many words toda... More for Gemini http://t.co/LuGOjNpNUo', 'negative', -0.6281, 'lost'),
('JRDavies_', 'Lost my touch fully ðŸ˜’', 'negative', -0.731855, 'lost'),
('ItsRissa_baby', 'Your message could get lost in a flurry of too many words toda... More for Gemini http://t.co/w5epYrzSHv', 'negative', -0.6281, 'lost'),
('FormidableTH14', 'Fucking hell. Javi Martinez next to Ramsey is beyond perfect. The two would compliment each other better than Vieira/Gilberto. Maybe.', 'positive', 0, 'better'),
('BabyLove_169', 'Better late than never :p x http://t.co/DnGVovhHBY', 'neutral', 0, 'better'),
('_ZombieFrida', '@_gaabyy u better come to school!!!!!!', 'positive', 0, 'better'),
('bestseven79', 'Guided life-review helps moderate depression: NEW YORK (Reuters Health) - A self-help process aimed at better ... http://t.co/QLUtASKgF4', 'positive', 0, 'better'),
('Iam_Vixen92', 'RT @IntThings: Ten steps to a better life http://t.co/unQObJ7hRY', 'positive', 0, 'better'),
('LakasTamaPare', 'Yesterday is gone. Today is okay. Tomorrow will be better.', 'positive', 0, 'better'),
('IamDarnell_4', 'You Deserve Better', 'neutral', 0, 'better'),
('juliefairbourn1', 'Guided life-review helps moderate depression: NEW YORK (Reuters Health) - A self-help process aimed at better ... http://t.co/dcePp6jhI2', 'positive', 0, 'better'),
('walker8701', 'RT @SirAlexStand: Gary Neville: "Them Liverpool fans know this was their only chance. Chelsea, City, Arsenal and United will be too strong â€¦', 'neutral', 0, 'arsenal'),
('ahapodolski', 'RT @Gunner_Updates: Giroud and Jenkinson #Arsenal http://t.co/qHTUaMN7QY', 'neutral', 0, 'arsenal'),
('bonnymwangangi', 'RT @KTNKenya: Chelsea stole Eden Hazard from my house, says Arsene Wenger http://t.co/otnV3x37S7 by @GameYetu http://t.co/YxcChAuyOM', 'neutral', 0, 'arsenal'),
('Saadgooner40', 'On this day in 2006, #Arsenal played their final game at Highbury', 'neutral', 0, 'arsenal'),
('padhasaari', 'Arsenal Player of the Season - VOTE NOW.. It was #BFG for me.. http://t.co/PI4quzj9GW via @sharethis', 'neutral', 0, 'arsenal'),
('najih1992', 'RT @TeleFootball: Arsenal make approach to Bayern Munich to buy Â£32m Javi Martinez this summer. Story by @JWTelegraph http://t.co/DXhTtDNiq8', 'neutral', 0, 'arsenal'),
('GurjitAFC', '#Arsenal make approach to Bayern for Javi Martinez. http://t.co/o73C5jucgi', 'neutral', 0, 'arsenal'),
('akakiyani', 'RT @arsl1989: "@TeleFootball: Arsenal make approach to Bayern Munich to buy Â£32m Javi Martinez this summer.  http://t.co/lXOZXIkCZ9" \r\rPlzzâ€¦', 'neutral', 0, 'arsenal'),
('Will_iam_PG', 'RT @Football__Tweet: Barnsley have released former Arsenal midfielder Emmanuel Frimpong after getting relegated to League One. #BFC http://â€¦', 'neutral', 0, 'arsenal'),
('aina2104', 'RT @JoshDevineDrums: I think everybody should download @keek and follow me!!!!!!! https://t.co/F4l3RzjMEb', 'positive', 0.62862, 'apple'),
('__AmandaLee__', 'RT @JLo: #ILuhYaPapi @Meryl_Davis @danicamckellar @DancingABC #DWTS http://t.co/cDeZWSPliH http://t.co/iumNAlKTvU', 'positive', 0.519745, 'apple'),
('ZinaDprincess', 'Help the Smurfs build a village to call home! Play on iOS and Android. @BeelineGames #SmurfsVillage http://t.co/HPEfZU0LNx', 'positive', 0.382051, 'apple'),
('Shine_Zayn1D', 'RT @zaynmalik: Who wants to pre-order You &amp; I? :) x http://t.co/obKd49KJYk', 'positive', 0.68074, 'apple'),
('BlakeSamuelson', 'Who really do it like Red Apple FC tho? #FUT http://t.co/cGa5e8vRs3', 'negative', -0.191037, 'apple'),
('mitrank', 'United States 12. Not a Bad Thing - Justin Timberlake http://t.co/iH1FOI6LJ3 #Music #iTunes #iPhone #Apple', 'positive', 0.058998, 'apple'),
('moura_jessy', 'Earn free Smurfberries each week when you build one of the Smurfy Wonders in #smurfsvillage http://t.co/aZnUoiVUC1', 'positive', 0.621805, 'apple'),
('SMT_Ellis', 'Lauren is mad at meðŸ˜”ðŸ˜­', 'negative', -0.714895, 'mad'),
('Keya___', '@itskiera__ lmao is you mad or nah? Lil bitch.', 'negative', -0.45227, 'mad'),
('Jamie_KSP', '@Mdreadedtwit In many areas, 50% of people are expected to vote for them in the EU elections. Does that make all of them "mad colonels"? :P', 'negative', -0.123864, 'mad'),
('CharmAMG', 'Billie been mad sassy lately ðŸ˜‚ðŸ˜‚ðŸ˜‚ðŸ˜­', 'negative', -0.689355, 'mad'),
('mondomedeusah', 'Ma$e Just Be Saying Things To Get You Mad: Paul Thompson once shot the fair one with Blinky Blink When it beca... http://t.co/MpLTSCEJqS', 'positive', 0.0506985, 'mad'),
('syedzafar5', 'Commission probing Hamid Mir incident to recommence from May 14: KARACHI: The commission ofâ€¦ http://t.co/IbNe7XQRzW', 'neutral', 0, 'hamid mir'),
('QaimNazir', 'Commission probing Hamid Mir incident to recommence from May 14 http://t.co/z7TtWLoiQT', 'negative', -0.107433, 'hamid mir'),
('pk0333', '#Pak tribune Commission probing Hamid Mir incident to recommence from May 14 http://t.co/BX3b99wDim', 'negative', -0.105222, 'hamid mir'),
('PSSP92', 'Commission probing Hamid Mir incident to recommence from May 14: \n\n         KARACHI:Â The commission of ... http://t.co/W4AmlKCg70', 'negative', -0.132937, 'hamid mir'),
('PostQuickNews', '(News) Commission probing Hamid Mir incident to recommence from May 14 http://t.co/bY8asDRzSZ', 'negative', -0.107637, 'hamid mir'),
('jnnetworks', 'Commission probing Hamid Mir incident to recommence from May 14: \n\n         KARACHI:Â The commission of ... http://t.co/emyd6PMwmF', 'negative', -0.132937, 'hamid mir'),
('BeinggRizwan', '#rizwan #pakistan Commission probing Hamid Mir incident to recommence from May 14 http://t.co/aiClsFvTpf', 'negative', -0.116912, 'hamid mir'),
('imAsadAziz', '#Pakistan #News #TV Commission probing Hamid Mir incident to recommence from May 14', 'negative', -0.237068, 'hamid mir'),
('DAhmed64', 'Commission probing Hamid Mir incident to recommence from May 14: \n\n         KARACHI:Â The commission of ... http://t.co/sxfR6pgu8J', 'negative', -0.132937, 'hamid mir'),
('janAsgher', '#Asgher Ali# Commission probing Hamid Mir incident to recommence from May 14 http://t.co/6rerodbgmD', 'neutral', 0, 'hamid mir'),
('Nates_Doin_Work', 'RT @earlxsweat: THE SWAMP IS A NO FLEX ZONE YOU CANT FRONT ON THIS I AM THE UGLY TRUTH SPITTING IN YOUR FUCKING FACE EVERY DAY FOR THE RESTâ€¦', 'negative', -0.697175, 'rest'),
('AustinFNclaytoN', 'RT @earlxsweat: THE SWAMP IS A NO FLEX ZONE YOU CANT FRONT ON THIS I AM THE UGLY TRUTH SPITTING IN YOUR FUCKING FACE EVERY DAY FOR THE RESTâ€¦', 'negative', -0.697175, 'rest'),
('littlehedgehog9', '@O_Churchyard  gunna sell sterling  and buy willian then might spend rest on packs', 'positive', 0.802375, 'rest'),
('IBGDNA_', '"@ibgnaziha: GD sooo tired hm pls rest well, sleep well pls, ðŸ˜­ðŸ˜­ðŸ˜­ @IBGDRGN http://t.co/k2pjn5gmVK"', 'positive', 0.226792, 'rest'),
('harvesthouseng', 'The worship team on stage #WordHunt #Rest', 'neutral', 0, 'rest'),
('queenphuckintee', 'RT @_SoNnyMonTana: Damn!! Somebody forgot to mow the rest of his lawn.hahahahaha lmfaooooooo https://t.co/ZZu26Vai4P', 'negative', -0.454769, 'rest'),
('CountBastardo', '@mrs_coyle @cboy77 What the? Gravy hatred? *astonishes*\n\nMind you, I have a pathological hatred for mushy peas.', 'negative', -0.85459, 'hatred'),
('Uptomyknees', 'There are days where I feel a powerful, compelling hatred for my job and this industry in general.  \n\nToday is one of those days.', 'positive', 0.86156, 'hatred'),
('LibertySeeds', 'A brief introduction to the ethnic and religious hatred espoused by anti-Christian #bigot Mikey Weinstein: http://t.co/jYiMhIYmBx', 'negative', -0.813385, 'hatred'),
('DominicParrella', 'RT @ao_Buddha: There is no fire like passion No crime like hatred,No sorrow like separation, No sickness like hunger, And no joy like the jâ€¦', 'negative', -0.53343, 'hatred'),
('Hatred_Blur', 'RT @TEACHMEHOW2YEET: @XertzFA @Sinatra_eXs @Hatred_Blur THIS IS HOW YOU #YEET ---&gt; https://t.co/bFHnyrl64e', 'positive', 0.282578, 'hatred'),
('meganhuhn', 'I have a special kind of hatred for Ron John.', 'positive', 0.455915, 'hatred'),
('viienus', 'RT @ibGDhis: "In every scene,his rich emotional acting is undeniable.Sadness,anger,hatred, anxiety,longing.. these were all expressed fullyâ€¦', 'positive', 0.58472, 'hatred'),
('Raven0fLight', 'RT @icrushedmyhalo: Let our love and lust engage in a sinfully debaucherous affair.', 'positive', 0.21707, 'lust'),
('Sammy_Desiree', 'RT @Rohbyn_arr: Thin lines separating love, lust, and infatuation.', 'negative', -0.0805595, 'lust'),
('Klaraea', 'You must learn not to lust after the things of this world with your eyes, whether itâ€™s a woman, an apple pie, or a new car you canâ€™t afford', 'negative', -0.287993, 'lust'),
('YixingXing10', 'RT @An_nur77: âœ˜-egoism,\nâœ˜-arrogance,\nâœ˜-conceit,\nâœ˜-selfishness,\nâœ˜-greed,\nâœ˜-lust,\nâœ˜-intolerance,\nâœ˜-anger,\nâœ˜-lying,\nâœ˜-cheating,\nâœ˜-gossiping anâ€¦', 'positive', 0.104627, 'lust'),
('BNMRadioNP', '#NowPlaying: Movement - Like Lust', 'positive', 0.294553, 'lust'),
('Tadoe_Hbmg', 'ain tryna cuff dese bitches i just wanna lust these bitches', 'negative', -0.830395, 'lust'),
('darklanddss', 'RT @_LunarAshes: all i ever say is â€œughâ€ because it can show confusion, lust, disgust and contempt, and thatâ€™s pretty much my life', 'negative', -0.462709, 'lust'),
('lojee21', '#Pakistani #Food Commission probing Hamid Mir incident to recommence from May 14 http://t.co/TCOkZzL9n0 #Recipe', 'positive', 0.287549, 'hamid mir'),
('khalidrafiq107', 'Commission probing Hamid Mir incident to recommence from May 14 http://t.co/emjQ4kdVsY', 'negative', -0.107433, 'hamid mir'),
('hoursnews', 'Commission probing Hamid Mir incident to recommence from May 14 http://t.co/zhv01kxgyV', 'negative', -0.107433, 'hamid mir'),
('coolapps3', '#Pakistani #Women Commission probing Hamid Mir incident to recommence from May 14 http://t.co/gE1VnZMeuM', 'negative', -0.108308, 'hamid mir'),
('basima__', 'RT @Ahmad_Noorani: Logic &amp; Politics of PTI:\nTweet-1: Hamid Mir was not attacked as no bllod on back seat.\nNext Tweet: Hamid Mir was attackeâ€¦', 'positive', 0.10837, 'hamid mir'),
('Ahmad_Noorani', 'Logic &amp; Politics of PTI:\nTweet-1: Hamid Mir was not attacked as no bllod on back seat.\nNext Tweet: Hamid Mir was attacked by owners of Geo.', 'neutral', 0, 'hamid mir'),
('nazazaidi', 'RT @fauji_tweets: Hunger Strike in favor of Geo at Lahore Press Club is as genuine as Hamid Mir False Flag. #WhyIHateGeoWithPassion', 'neutral', 0, 'hamid mir'),
('anjPk', '@Ahmad_Noorani geo is ready to fire aamir,hamid mir, najam sethi, ansar abbasi n thr stupid umer cheema...', 'negative', -0.293344, 'hamid mir'),
('hermithere', 'RT @fauji_tweets: Hunger Strike in favor of Geo at Lahore Press Club is as genuine as Hamid Mir False Flag. #WhyIHateGeoWithPassion', 'neutral', 0, 'hamid mir'),
('thisiszoaib', 'Saleem Safi busted.    "@naskhan206: @khalidkhan787 @wajih_sani  IK said i called Hamid Mir his phone was off so i texted him."', 'negative', -0.419656, 'hamid mir'),
('shortandfunny', '#Pakistani #Women Commission probing Hamid Mir incident to recommence from May 14 http://t.co/MImIRbLY3g', 'negative', -0.108308, 'hamid mir'),
('lojee21', '#Pakistani #Food Commission probing Hamid Mir incident to recommence from May 14 http://t.co/TCOkZzL9n0 #Recipe', 'positive', 0.287549, 'hamid mir'),
('khalidrafiq107', 'Commission probing Hamid Mir incident to recommence from May 14 http://t.co/emjQ4kdVsY', 'negative', -0.107433, 'hamid mir'),
('hoursnews', 'Commission probing Hamid Mir incident to recommence from May 14 http://t.co/zhv01kxgyV', 'negative', -0.107433, 'hamid mir'),
('coolapps3', '#Pakistani #Women Commission probing Hamid Mir incident to recommence from May 14 http://t.co/gE1VnZMeuM', 'negative', -0.108308, 'hamid mir'),
('basima__', 'RT @Ahmad_Noorani: Logic &amp; Politics of PTI:\nTweet-1: Hamid Mir was not attacked as no bllod on back seat.\nNext Tweet: Hamid Mir was attackeâ€¦', 'positive', 0.10837, 'hamid mir'),
('Ahmad_Noorani', 'Logic &amp; Politics of PTI:\nTweet-1: Hamid Mir was not attacked as no bllod on back seat.\nNext Tweet: Hamid Mir was attacked by owners of Geo.', 'neutral', 0, 'hamid mir'),
('nazazaidi', 'RT @fauji_tweets: Hunger Strike in favor of Geo at Lahore Press Club is as genuine as Hamid Mir False Flag. #WhyIHateGeoWithPassion', 'neutral', 0, 'hamid mir'),
('anjPk', '@Ahmad_Noorani geo is ready to fire aamir,hamid mir, najam sethi, ansar abbasi n thr stupid umer cheema...', 'negative', -0.293344, 'hamid mir'),
('hermithere', 'RT @fauji_tweets: Hunger Strike in favor of Geo at Lahore Press Club is as genuine as Hamid Mir False Flag. #WhyIHateGeoWithPassion', 'neutral', 0, 'hamid mir'),
('F1Barca', 'Nokia Joins Autonomous Car Development With $100M Fund http://t.co/vzOgRKRmma', 'positive', 0.67025, 'nokia'),
('daisysflower83', '#GIVEAWAY | Nokia 928 @windowsphone &amp; Nokia Lumia 2520 @windows tablet @ourkidsmom #WindowsChampions #momsgifts http://t.co/W4FLjemlQF', 'positive', 0.54624, 'nokia'),
('galabengazi', 'Buy HTC One ( M8 ) $400/Samsung Note 3 $400/LG G2 $380/Nokia X+/Google Nexus 5 http://t.co/Ahtu3hnvsB', 'positive', 0.204727, 'nokia'),
('galabengazi', 'Buy BlackBerry Porsche Pâ€™9982 $600/Sony Xperia Z2 $400/HTC One ( M7 )$350/Nokia XL http://t.co/o1O7PaVp99', 'neutral', 0, 'nokia'),
('steven_seow', 'RT @nokia: Friends in APAC and IMEA Regions -- the XL has landed :) http://t.co/JpU6mbqNIL http://t.co/cRSWrx8mRl', 'positive', 0.681155, 'nokia'),
('naruto_arnab', '@nokia_connects #ConnectsComp The heritage of Kolkata!! http://t.co/ZrAGjDisMb', 'positive', 0.183989, 'nokia'),
('Saraktm', 'RT @nokia: Friends in APAC and IMEA Regions -- the XL has landed :) http://t.co/JpU6mbqNIL http://t.co/cRSWrx8mRl', 'positive', 0.681155, 'nokia'),
('forumerindia', 'RT @BreakingNews: Pakistani army says bomb blast kills 8 security officials in tribal region near Afghan border - @AP', 'negative', -0.177312, 'Army'),
('JET_Army', 'RT @funnyortruth: The Love Story Between Tomato And Potato Teaches Us One Thing http://t.co/VKUP6beKIs', 'positive', 0.732785, 'Army'),
('AzrulnizamBZ', '"@MattHurairah: Palestinian lady collects gas bombs fired by Israeli army. She grows flowers in these bombs http://t.co/T0MI1xhjBm"', 'negative', -0.476741, 'Army'),
('johanalexnder', 'RT @MattHurairah: Palestinian lady collects gas bombs fired by Israeli army. She grows flowers in these bombs http://t.co/Zltw7VYP35', 'negative', -0.394623, 'Army'),
('azizulhafiz98', 'RT @BalotMalaysia: Italian protesters broke into a US Army installation and planted about 200,000 marijuana seeds. https://t.co/TqfSY5zgyS â€¦', 'negative', -0.12516, 'Army'),
('CocosGist', 'RT @ayosogunro: Quick question: is it possible to volunteer for temporary duty in the Nigerian Army? Say a six month/one year tour in Bornoâ€¦', 'positive', 0.286705, 'Army'),
('MarmehEatsGrass', 'RT @SJsSapphireBlue: #WeWillWaitForLeeteuk 82 days left before Leeteuk is released from the army.D-525 of waiting for Park Jungsoo â™¥ http:/â€¦', 'neutral', 0, 'Army'),
('TheWildcatLair', 'Celtkicks: New Rajon Rondo Anta athletic shoe | Red&amp;#039;s Army - The Voice of Boston Celtics Fans - http://t.co/yD0lYyxZbr  #BBN', 'positive', 0.36013, 'Army'),
('gawdenews', 'Army: Roadside bomb kills 8 in northwest Pakistan - KMPH Fox 26 http://t.co/MbZ3SdB8X2 http://t.co/vitmymG8ZS', 'negative', -0.450222, 'Pakistan Army'),
('ViSalusHTX', 'Army: Roadside Bomb Kills 8 in Northwest Pakistan http://t.co/ZAXTfF5IIA #magazine #2013 #13', 'negative', -0.126454, 'Pakistan Army'),
('h0p_ksks', 'Army: Roadside Bomb Kills 8 In Northwest Pakistan: Army: Roadside bomb kills 8 in northwest Pakistan http://t.co/IKhaetTDom', 'negative', -0.64828, 'Pakistan Army'),
('DoyleGlobal', 'Army: Roadside bomb kills 8 in northwest Pakistan - KMPH Fox 26 http://t.co/hrciD7ONz5', 'negative', -0.479645, 'Pakistan Army'),
('azaad_pakistan', 'Is Pak Army Consuming 80 % of the Budget - http://t.co/fM2k7wuEoj', 'negative', -0.51029, 'Pakistan Army'),
('fahad_marwat', '@abbasnasir59 @AliAbbasi3 @Pakistan_Army @Ahmad_Noorani ya #geo is on top thats my point :)', 'positive', 0.849045, 'Pakistan Army'),
('RealTimeHack', 'Army says roadside bomb kills 8 paramilitary soldiers in northwest Pakistan near Afghan border http://t.co/q4KRDajNVw #NLU', 'neutral', 0, 'Pakistan Army'),
('MIlyas081', 'RT @mushtaqminhas: Long live Hamid Mir http://t.co/ewJgYAFlBR', 'neutral', 0, 'Hamid Mir'),
('equal2death', '@UmarCheema1 I am a scholar of Mphill Human resource. after the attack on Hamid Mir I cant resist to stop my self from writing a column', 'negative', -0.58607, 'Hamid Mir'),
('Addi_010', 'RT @shariqa_ahmed: Hamid Mir____________Another Iftekhar Choudhry? http://t.co/AnUaumrq4z\nBlog by @sahussain90', 'positive', 0.254241, 'Hamid Mir'),
('NamwarJanwar', 'RT @SabbabaK: Produce and direct best dramas\n-Sikandar &amp; Zamrud Khan \n-Mystery of Malala\n-Curious case of Hamid Mir\n-Blames of Amir Mir \n~iâ€¦', 'positive', 0.31365, 'Hamid Mir'),
('Mobeen_asram', 'RT @mushtaqminhas: Long live Hamid Mir http://t.co/ewJgYAFlBR', 'neutral', 0, 'Hamid Mir'),
('Wiseguy70', '@salmanarshad @fauji_tweets Prove it,Hamid Mir must leave his profession &amp;must try his luck in acting,a person hit with 6 bullets &amp;Survived?', 'positive', 0.187963, 'Hamid Mir'),
('shahidsithari', 'RT @HafizSaeedJUD: Attack on Hamid Mir was attack on an individual, while attack on Armed forces was on Pakistan, whole nation #Lahore #Istâ€¦', 'negative', -0.0542615, 'Hamid Mir'),
('shariqa_ahmed', 'Hamid Mir____________Another Iftekhar Choudhry? http://t.co/AnUaumrq4z\nBlog by @sahussain90', 'positive', 0.269063, 'Hamid Mir'),
('SardarAlig7', '@MaryamNSharif @ShkhRasheed After meeting b/w Zard n NS attack occurs n Straight Blame game on ISI why? Why People Dont understand big game.', 'negative', -0.47951, 'blame on ISI'),
('abrarnaveed', '@Ahmad_Noorani @MurtazaGeoNews by barking against isi u already given golden chance to RAW to attack on u so the blame on isi easily.#shame', 'negative', -0.861515, 'blame on ISI'),
('omararshad', 'Geo claiming that it might be editorial mistake to blame DG ISI for attack on Hamid Mir. Editorial mistake 8 hrs ki nai hoti bhai. #BanGeo', 'negative', -0.373488, 'blame on ISI'),
('Chupppehhh', 'RT @ThatsMyHandle: tomorrows Headlines "PeerSaab ne kiya do do Qatl" !!! @Chupppehhh @FakePeer ! Blame it on ISI ?? LoL', 'positive', 0.251445, 'blame on ISI'),
('ThatsMyHandle', 'tomorrows Headlines "PeerSaab ne kiya do do Qatl" !!! @Chupppehhh @FakePeer ! Blame it on ISI ?? LoL', 'positive', 0.184481, 'blame on ISI');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
