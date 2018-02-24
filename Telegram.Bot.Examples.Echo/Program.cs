using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Telegram.Bot.Args;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.InlineQueryResults;
using Telegram.Bot.Types.InputMessageContents;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram.Bot.Examples.Echo
{
    class Program
    {
        private static readonly TelegramBotClient Bot = new TelegramBotClient("411237988:AAEaMfwCFrS70ZVQSil8q74CKdrQgnZnfEc");

        static void Main(string[] args)
        {
            Bot.OnCallbackQuery += BotOnCallbackQueryReceived;
            Bot.OnMessage += BotOnMessageReceived;
            Bot.OnMessageEdited += BotOnMessageReceived;
//          Bot.OnInlineQuery += BotOnInlineQueryReceived;
            Bot.OnInlineResultChosen += BotOnChosenInlineResultReceived;
            Bot.OnReceiveError += BotOnReceiveError;

			var me = Bot.GetMeAsync().Result;

            Console.Title = me.Username;

            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static void BotOnReceiveError(object sender, ReceiveErrorEventArgs receiveErrorEventArgs)
        {
            Debugger.Break();
        }

        private static void BotOnChosenInlineResultReceived(object sender, ChosenInlineResultEventArgs chosenInlineResultEventArgs)
        {
            Console.WriteLine($"Received choosen inline result: {chosenInlineResultEventArgs.ChosenInlineResult.ResultId}");
        }

        private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;
            var ID = message.Chat.Username;
            var Owner = message.Chat.Username;
            var chatid1 = message.Chat.Id;
            Int64 chatid = Convert.ToInt64(chatid1);
            var log = "Message Recieved From: " + "@" + ID + "   " + "Message: " + message.Text +  "   " + @"Chat Id: " + chatid;


            Console.WriteLine(log);

            if (message == null || message.Type != MessageType.TextMessage) return;

            if (Owner == "EvanWusky" || Owner == "FriendlyDaWusky" || Owner == "KyleTheHusky" || Convert.ToBoolean(363521044))
            {
                if (message.Text.StartsWith("/op"))
                {
                    await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

                    var welcome = @"Welcome   " + Owner + @"To The Owner Control Menu";

                    await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);



                    await Task.Delay(500); // simulate longer running task
                        
                    await Bot.SendTextMessageAsync(message.Chat.Id, welcome);
                    Console.WriteLine("/op command was used");
                }

                if(message.Text.StartsWith(@"/adlist"))
                {
                    await Bot.GetChatAdministratorsAsync(-1001132957029);
                }

                if(message.Text.StartsWith(@"/id"))
                {
                    await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

                    var id = chatid;

                    await Bot.SendTextMessageAsync(message.Chat.Id, id.ToString());
                    Console.WriteLine(message.Chat.Id);
                    Console.WriteLine(@"/id Command Was Used");
                }

            }


           else if (Owner != "EvanWusky" || Owner != "FriendlyDaWusky" || Owner != "KyleTheHusky")
            {
                if (message.Text.StartsWith("/op"))
                {
                    await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

                    var operror = @"Error You Are Not The Group Owner Or Bot Creator";
                   
                    await Bot.SendTextMessageAsync(message.Chat.Id, operror);
                    Console.WriteLine("/op command was used");
                }
            }
            #region /owner

            if (Owner == "EvanWusky" || Owner == "FriendlyDaWusky" || Convert.ToBoolean(363521044))
            {
                if (message.Text.StartsWith("/owner"))
                {
                    await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

                    var welcome = @"Welcome   " + Owner + @"To The Owner Control Menu";

                    await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

                    await Task.Delay(500); // simulate longer running task

                    await Bot.SendTextMessageAsync(message.Chat.Id, welcome);
                    Console.WriteLine("/owner command was used");
                }
            }

                if (Owner != "EvanWusky" || Owner != "FriendlyDaWusky")
                {
                    if (message.Text.StartsWith("/owner"))
                    {
                    var operror = @"Error You Are Not The Group Owner Or Bot Creator";

                        await Bot.SendTextMessageAsync(message.Chat.Id, operror);
                        Console.WriteLine("/owner command was used");
                    }
                }

                
                    #endregion

                    if (message.Text.StartsWith("/staff")) // send inline keyboard
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

                var admins = @"
Owner:
@KyleTheHusky

Admins:
@Shred
@Airborne_Cheetah
@EvanWusky
@RiversCuomo
@DoughnutWuff
@AstroWolfe
@DessFachs
@Caseythehusky
@CliveTheWuskie
@StoneNeely
";

                await Bot.SendTextMessageAsync(message.Chat.Id, admins);
                Console.WriteLine(@"/staff Command Was Used");
            }

            else if(message.Text.StartsWith("/help"))
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
                var help = @"Usage:
WIP Bot - Creators First Time Coding

Commands
/rules - Show Rules For The Fluffers Chat
/staff - Lists Admins
/photo -Sends A photo
/pic - Sends A Different photo
/help - This Command
";

                await Bot.SendTextMessageAsync(message.Chat.Id, help);
                    Console.WriteLine(@"/help Command Was Used");

            }

            else if (message.Text.StartsWith("/rules"))
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
                var rules = @"Rules:
do /rules to seem them again

Hi yea to all those that have come into the chat, I do have rules so follow them if you don't wanna get kicked out

1. No Drama in the Chat, because i dont wanna pick up the pieces when you get kicked out

2. No Racism or just bullying pepole in the chat is not permitted

3. Spamming the chat with letters and complete and utter gibberish is not permitted


4. No speaking about Alcohol And/Or Drugs as two of our members here are very senitive to the subject matter!


5. Just have a great time in Fluffers Land

Warnings And Notes
- Anti Flood will kick You after 11 Items
- reply to a message with @admin to contact all admins
- Every Admin Action that takes place (By admins or the Bot) is logged in a Private channel that all admins are in

Affiliate Groups 
@FurryLifeRP
@FurryLifeRPnsfw
@fursupportgroup";
                await Bot.SendTextMessageAsync(message.Chat.Id, rules);
                Console.WriteLine(@"/rules Command Was Used");
            }

            else if (message.Text.StartsWith("/edit"))
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
                var edit = @"The edit Command is still a wip";

                await Bot.SendTextMessageAsync(message.Chat.Id, edit);
                Console.WriteLine(@"/edit Command Was Used");

            }

            else if (message.Text.StartsWith("/link"))
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
                var link = @"https://t.me/joinchat/CJRrskOHjWWNR0pDbaFJfQ";

                await Bot.SendTextMessageAsync(message.Chat.Id, link);
                Console.WriteLine(@"/link Command Was Used");

            }

            else if (message.Text.StartsWith("/photo")) // send a photo
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

                const string file = @"D:\Downloads\New folder\3079b146f5a103068ed9cb1adbb9365be01abfe5_hq.jpg";

                var fileName = file.Split('\\').Last();

                using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var fts = new FileToSend(fileName, fileStream);

                    await Bot.SendPhotoAsync(message.Chat.Id, fts, "Nice Picture");
                    Console.WriteLine("/photo command was used");
                }
            }

            else if (message.Text.StartsWith("/pic")) // send a photo
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.UploadPhoto);

                const string file = @"D:\Downloads\New folder\1477427131.falvie_fail.png";

                var fileName = file.Split('\\').Last();

                using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    var fts = new FileToSend(fileName, fileStream);

                    await Bot.SendPhotoAsync(message.Chat.Id, fts, "Nice Picture");
                    Console.WriteLine("/pic command was used");
                }
            }

            else if (message.Text.ToLower().StartsWith("MY BOT FUCKING HATES ME"))
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
                var FU = @"I HATE YOU TO NOW FUCK YOU FUCK YOU FUCK YOU";

                await Bot.SendTextMessageAsync(message.Chat.Id, FU);
                Console.WriteLine(@"MBFHM Command Was Used");

            }

            else if (message.Text.ToLower().StartsWith("How is everyone"))
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);

                var hru = @"I am Fine";

                await Bot.SendTextMessageAsync(message.Chat.Id, hru);
                Console.WriteLine(@"hru1 Command Was Used");

            }

            else if (message.Text.ToLower().Contains("How is everyone"))
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
                var hru = @"I am Fine";

                await Bot.SendTextMessageAsync(message.Chat.Id, hru);
                Console.WriteLine(@"hru1 Command Was Used");

            }

            else if (message.Text.ToLower().Contains("how is everyone"))
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
                var hru = @"I am Fine";

                await Bot.SendTextMessageAsync(message.Chat.Id, hru);
                Console.WriteLine(@"hru1 Command Was Used");

            }

            else if (message.Text.ToLower().StartsWith("hru"))
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
                var hru = @"I am Fine";

                await Bot.SendTextMessageAsync(message.Chat.Id, hru);
                Console.WriteLine(@"hru2 Command Was Used");

            }

            else if (message.Text.ToLower().Contains("hru"))
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
                var hru = @"I am Fine";

                await Bot.SendTextMessageAsync(message.Chat.Id, hru);
                Console.WriteLine(@"hru2 Command Was Used");

            }

            else if (message.Text.ToLower().Contains("ill fix it next time"))
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
                var fix = @"Knowing You Creator, It wont Happen For a while";

                await Bot.SendTextMessageAsync(message.Chat.Id, fix);
                Console.WriteLine(@"fix Command Was Used");

            }

            else if (message.Text.ToLower().StartsWith("yiff"))
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
                var yiffc = @"Can you not infront of my Salad";

                await Bot.SendTextMessageAsync(message.Chat.Id, yiffc);
                Console.WriteLine(@"yiff comment Command was used");

            }

            else if (message.Text.ToLower().Contains("yiff"))
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
                var yiffc2 = @"Can you not infront of my Salad";

                await Bot.SendTextMessageAsync(message.Chat.Id, yiffc2);
                Console.WriteLine(@"yiff comment2 Command was used");

            }

            else if (message.Text.ToLower().Contains("pls dont break bot"))
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
                var botbreak = @"I WILL BREAK IF I WANT";

                await Bot.SendTextMessageAsync(message.Chat.Id, botbreak);
                Console.WriteLine(@"break Command Was Used");

            }

            else if (message.Text.ToLower().Contains("owo"))
            {
                await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
                var owo = @"*Notices Your buldge Whats this*";

                await Bot.SendTextMessageAsync(message.Chat.Id, owo);
                Console.WriteLine(@"owo Command Was Used");

            }

			else if (message.Text.ToLower().Contains("awooo"))
			{
				await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
				var owo = @"AWOOOOOOOOOOOOOOOOOOO";

				await Bot.SendTextMessageAsync(message.Chat.Id, owo);
				Console.WriteLine(@"awooo Command Was Used");

			}

			else if (message.Text.ToLower().Contains("awoo"))
			{
				await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
				var owo = @"AWOOOOOOOOOOOOOOOOOOO";

				await Bot.SendTextMessageAsync(message.Chat.Id, owo);
				Console.WriteLine(@"awooo Command Was Used");

			}
			
			else if (message.Text.ToLower().Contains("damit bot"))
			{
				await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
				var damit = @"What I Cant Help But Overload Or Stop Working Sometimes";

				await Bot.SendTextMessageAsync(message.Chat.Id, damit);
				Console.WriteLine(@"Damit Command Was used");

			}

			else if (message.Text.ToLower().Contains("this bot is fun"))
			{
				await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
				var fun = @"Who Ever Said Im Fun Why Thank You";

				await Bot.SendTextMessageAsync(message.Chat.Id, fun);
				Console.WriteLine(@"Bot Is Fun Command Was used");

			}

			else if (message.Text.ToLower().Contains("gay"))
			{
				await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
				var gay = @"NO..... Alright Maybe I Do *Vomits Rainbows* There That Better";

				await Bot.SendTextMessageAsync(message.Chat.Id, gay);
				Console.WriteLine(@"Gay Command Was used");

			}

			else if (message.Text.ToLower().Contains("meep"))
			{
				await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
				var meep = @"Beep Beep Im A Sheep";

				await Bot.SendTextMessageAsync(message.Chat.Id, meep);
				Console.WriteLine(@"Meep Command Was used");

			}

			else if (message.Text.ToLower().Contains("*starts yiffing the bot *"))
			{
				await Bot.SendChatActionAsync(message.Chat.Id, ChatAction.Typing);
				var meep = @"*Whacks No Bad Furry/Person Leave Me Alone";

				await Bot.SendTextMessageAsync(message.Chat.Id, meep);
				Console.WriteLine(@"yiffing Command Was used");

			}
					//MEEP

		}
        private static async void BotOnCallbackQueryReceived(object sender, CallbackQueryEventArgs callbackQueryEventArgs)
        {
            await Bot.AnswerCallbackQueryAsync(callbackQueryEventArgs.CallbackQuery.Id,
                $"Received {callbackQueryEventArgs.CallbackQuery.Data}");
        }
    }
}
