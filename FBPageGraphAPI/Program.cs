using FBPageGraphAPI;

var pageId = "YOUR_PAGE_ID";
var accessToken = "YOUR_ACCESS_TOKEN";
var link = "https://www.code-mega.com/";
var message = "🔔🔔🔔🔔 **Bài Viết Mới** 🔔🔔🔔🔔 \n 💗💗💗💗💗💗💗💗💗💗💗💗💗💗 \n 👇👇👇👇Xem chi tiết tại đây 👇👇👇👇";

// Post news
var postId = await FacebookPageHelper.CreateAsync(pageId, accessToken, link, message);
Console.WriteLine(postId);

// Delete Post
var delPostId = "";
var success = await FacebookPageHelper.DeleteAsync(delPostId, accessToken);