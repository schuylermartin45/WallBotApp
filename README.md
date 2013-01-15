WallBotApp
==========

Wall bot application that uses human skin detection and speech recognition to record messages on a door mounted laptop

To run WaLLBoT:

Download executable from: https://sites.google.com/site/nitramproductionsonline/games/wallbot
(or compile it yourself)

Requires:
.NET 4.0 or above (Windows XP, Vista, 7, 8, etc.)
Microsoft Expression Studio Encoder 4 (demo free for download from Microsoft, runs video libraries)


MIT License:

The MIT License (MIT)
Copyright (c) <year> <copyright holders>

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

Log in to post comments
Comments
Fri, 2009-03-13 19:53 — administrator
Additional Clause Requested
As stated the law allows abuses of software. Require a clause that no malicious uses may be entered into with said program conditional of any use. Martin M. Musatov
Log in to post comments
Fri, 2009-07-17 19:38 — nelson
The problem with a clause
The problem with a clause like that is: who gets to define what is malicious use? What happens if that entity ceases to make those decisions?
Log in to post comments
Wed, 2009-04-29 16:52 — administrator
How can i use this?
If i want distribute open source system CMS on my site http://correct.com.ua/ can i use this license?
Log in to post comments
Fri, 2009-07-17 19:37 — nelson
Yes, of course you can use
Yes, of course you can use this license. Just include the text of the license in a file called "LICENSE", and make reference to it in a file called "README".
Log in to post comments
Fri, 2009-07-24 06:07 — administrator
A Question
I downloaded a software under this License. Upon the original software I have made several changes. I would like to release our it with those changes. What kind of licensing can it go with ?(with the Same license ?) Is it possible to keep the changes under my name ?
Log in to post comments
Mon, 2009-07-27 16:18 — administrator
Another question
If we are making a closed source application, selling this application for profit, include this license in the open source license file, are we breaking any laws? Thank you for your time.
Log in to post comments
Mon, 2009-12-28 14:47 — administrator
It's perfectly OK.
Feel free to use MIT/X11 licensed code in your non-open-source apps. You are allowed to link to such code from your application or even change the licence of derivative works (see the permission to "sub-license"). What you may need to do is give attribution: http://en.wikipedia.org/wiki/Attribution_%28copyright%29 I.e: say "libfunctionality , Copyright by J. Random Hacker, 2009" somewhere. But it would be hard to avoid giving attribution in practically all copyrighted open source code out there. ------------------ Shlomi Fish, http://www.shlomifish.org/ When Chuck Norris uses Gentoo, "emerge kde" finishes in under a minute. A computer cannot afford to keep Chuck waiting for too long.
Log in to post comments
Tue, 2009-07-28 07:47 — administrator
Referring to license via URL
Is it sufficient to refer to the license via URL? I want to modify and use some code that only refers to the license via: /* Licensed under the MIT license: http://www.opensource.org/licenses/mit-license.php */ Is it OK to integrate code within a larger code-base (e.g. using some MIT-licensed JavaScript within a larger javascript library) with a wrapper / comment inserted in the appropriate place: /* Function foobar derived from MIT-licensed code: http://www.opensource.org/licenses/mit-license.php */ Note: I've no idea of the legal significance of changing "Licensed under the MIT license" to "Derived from MIT licensed code" - hence the question.
Log in to post comments
Mon, 2009-12-28 14:41 — administrator
I think so.
I am not a lawyer, but I think it's good enough. A lot of JavaScript out there does not put the entire licence blurb there to save space. Pedantics (like the Debian project) also need a "Copyright by Foo Bar, 2009" statement. Regarding the wrapper - it should be OK, but make sure you also reproduce the copyright blurb and a link to the one who originated it. I should note that MIT/X11-licensed code can be sub-licensed to any other licence. ------------------ Shlomi Fish, http://www.shlomifish.org/ When Chuck Norris uses Gentoo, "emerge kde" finishes in under a minute. A computer cannot afford to keep Chuck waiting for too long.
Log in to post comments
Fri, 2010-01-08 13:44 — administrator
How To Comply
I'd like to use some MIT-licensed xml-parsing code in my iPhone game. This seems to require that I package the MIT license with the application. However, my iPhone app does not include extensive documentation and my demographic will not want legal notices shoved in their faces. My boss is afraid of using this code because our company is very small and doesn't have the money for any type of legal battle. What is the best way to comply with the MIT license in an iPhone app without compromising user experience? ___________ Samuel Fattizi
Log in to post comments
Tue, 2010-03-16 06:37 — administrator
Sublicensing
If I obtain code under the MIT license, then make changes to it. Can I sub-license it under my own terms? Or do I have to still include their original MIT license with my software. Basically I'm creating software that contains MIT licensed code, but I want to sell it with my own sub-license for the end users so they can't redistribute it for free.
Log in to post comments
Mon, 2012-01-23 17:52 — bloggertom
Yes
Your well within your right to do that so long as the MIT parts retain a copy of the license.
Log in to post comments
Thu, 2010-04-15 23:11 — administrator
Copyleft or not?
>The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software. Then why does Wikipedia state (unreferenced) this license is NOT copyleft? Does Wikipedia need fixing? Is there a reliable source about this?
Log in to post comments
Wed, 2011-05-25 15:40 — administrator
MIT License is NOT Copyleft
Copyleft refers to whether the license perpetuates to derivatives based on the licensed work. For example, GPL license requires programs that use material from GPL licensed software to be licensed under the GPL. MIT does not have this requirement.
Log in to post comments
Thu, 2011-08-18 08:35 — administrator
No, the MIT license is NOT "Copyleft".
No, the MIT license is NOT "Copyleft". Copyleft licenses are designed for authors of 'free' software, who wish to ensure that their work can ONLY be used in other 'free' software. Such an author chooses a path where everyone contributes 'free' software, and no one can include such work in 'un-free' software. [As always, referring to everyone's ability to distribute, build on, modify, etc, the software, not to price.] The MIT license is different. It is for authors who are willing to have their work be widely used, in both 'free' and commercial (proprietary) software. That is, it is fine with such an author if someone else makes use of their work, but feels that they are not in a position to offer such freedom. These are two philosophically different paths for sharing work with the broader community. Each path has its benefits. There is also a third alternative, represented by LGPL (The "Lesser Freedom" license). Here, the work itself must remain 'free' - all modifications to it must be made available to everyone, but it can be *linked* with 'non-free' work, as long as certain conditions are maintained. For example, I make my living developing custom software for clients. I (or my clients) have a business model that is not consistent with CopyLeft freedom. Therefore, I only use MIT licensed or LGPL licensed software.
Log in to post comments
Thu, 2011-08-18 09:04 — administrator
not copyleft because your changes may be different license
I just realized a possible source of confusion: The MIT license is only required to be retained for the work that you incorporate. You are free to use DIFFERENT LICENSING TERMS for any work that you add. You do NOT have to release your modifications under the MIT license. If the MIT license stated that you had to release YOUR changes under the same license, then it would indeed be CopyLeft. But it doesn't. Perhaps it should be revised to explicitly state that the right to modify/etc the software includes the right to use different licensing terms for the modified portions (as long as the original copyright is preserved/made-visible for the included work).
Log in to post comments
Tue, 2011-07-12 14:25 — administrator
Requirement to provide the source code
I'm referring to the following part-sentence: "to permit persons to whom the Software is furnished to do so" Does this mean that person1, referred to in the text as "any person", is required to give access to the complete source code to person2, referred to in the text as "persons to whom the Software is furnished"? I'm asking because it seems that you need the source code to "to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software", which is contradictory to the "without restriction" part?
Log in to post comments
Mon, 2012-03-05 15:58 — Anne Mouse
nope
The part about "permit persons to whom the software is furnished..." says that the license is sublicensable. In other words, person A gives software to person B, and under this license, not only can person B do various stuff (e.g. modify), but also, person B has the authority to give the same permissions (or any subset of permissions, as person B chooses) to any person(s) C that B chooses. Assuming person A is the copyright holder, it would be a little bit pointless for person A to choose this license if he didn't intend to include the source code. The license gives B the *right* to modify, so one hopes that person A would also give person B the *power* to do so. But the license doesn't force A to give B the source. It doesn't force B to give C the source either, even if B gets the source from A. Which makes sense, because B doesn't have to pass along any of the rights (e.g., right to modify) that B doesn't want to. If you choose this license, you are allowing anybody to take the source away and distribute only the binaries.
Log in to post comments
Mon, 2011-08-29 11:14 — administrator
Arabic Translation
يمكن الاطلاع على نسخة مترجمة للعربية على العنوان: http://os-licenses.richstyle.org/MIT-ar.php
Log in to post comments
Tue, 2012-01-17 20:49 — gthunen
How do I obtain an MIT license?
I'm a freelance graphic designer and would like to use the Flexslider widget on my site, but I need to first obtain an MIT license. How do I go about doing this?
Log in to post comments
Fri, 2012-03-02 07:20 — HolyPhoenix
Hi, I think you misunderstand what this is
I am glad you are worried about making sure you don't steal software. The MIT license is what you agree to when you use the software, not something you have to purchase though. So feel right ahead to use the slider, without purchasing anything. Just make sure you follow the rules stated by the MIT License above our posts. ;)
Log in to post comments
Mon, 2012-03-05 15:40 — Anne Mouse
it's included
Look inside the FlexSlider download for a file named LICENSE.txt :)
Log in to post comments
Tue, 2012-03-13 17:52 — akole
License inclusion term clarification
May I enquire as to what specific forms are permissable to meet the "...The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software..." requirement? For example, does the notice need to appear within an application's user interface somewhere? If so, does it matter where? If not, how specifically does it need to be incorporated? Embedded within any file? Only a separate file? What about a a phone app, where this would be impractical? What about a hardware product where the code is compiled into firmware and there is no practical or desirable way of displaying the notice? Thanks in advance!
Log in to post comments
