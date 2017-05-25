using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using recipeWebsite.Models;

namespace recipeWebsite.services
{
    public class DbInitializer
    {
        public static void Initialize(WebsiteContext context)
        {
            context.Database.EnsureCreated();

            if (context.Recipes.Any())
            {
                return;
            }
            string[] names = {
                "Grilled Spanish Mustard Beef",
                "Banana Banana Bread",
                "Chicken Broccoli Salad",
                "Shrimp Scampi with Pasta",
                "Creamy Herbed Pork Chops",
                "Roast Sticky Chicken-Rotisserie Style",
                "Broccoli Chicken Divan",
                "Bacon Ranch Pasta Salad",
                "Honey-Garlic Slow Cooker Chicken Thighs ",
                "Triple Dipped Fried Chicken",
                "Bruschetta Chicken Bake",
                "Slow-Cooker Barbecue Ribs",
                "Good Old Fashioned Pancakes ",
                "Stuffed Cabbage Rolls",
                "Meatball Nirvana"
            };
            string[] shortDescription =
            {
                "Chef John's grilled Spanish mustard beef uses a fantastic Dijon mustard rub with paprika and sherry vinegar to give the steak a delicious flavor.",
                "This banana bread recipe is moist and delicious, with loads of banana flavor. It's wonderful toasted!",
                "This broccoli salad is a great way to use up leftover grilled chicken. The tangy mayonnaise dressing is easy to whip up, too.",
                "Shrimp are served with linguine pasta in a white wine-and-butter sauce flecked with fresh parsley for a quick and impressive main dish.",
                "Skillet cooked pork chops with an herbed cream sauce will have you in comfort food heaven!",
                "Ever wish you could get that restaurant-style rotisserie chicken at home? Well, with minimal preparation and about 5 hours' cooking time, you can!",
                "Fresh broccoli and chicken bake in a savory sauce topped with a crunchy, cheesy topping for a casserole they'll love.",
                "This is a very flavorful pasta salad. The crisp cooked bacon really adds a nice flavor. I get requests for this pasta salad for every get together and cook out.",
                "This is the crispiest, spiciest, homemade fried chicken I have ever tasted! It is equally good served hot or cold and has been a picnic favorite in my family for years.",
                "This is an easy slow cooker recipe for chicken thighs in a sauce made with soy sauce, ketchup, and honey.",
                "A simple, delicious chicken-and-stuffing casserole made with chicken breasts, tomatoes, Italian seasonings, and mozzarella cheese.",
                "Make delicious, fluffy pancakes from scratch. This recipe uses 7 ingredients you probably already have.",
                "Slow cooker barbecue ribs are an easy and delicious way of making barbecue ribs without the barbecue.",
                "Cabbage leaves filled with ground beef and rice are simmered in tomato soup for this Polish-inspired favorite.",
                "Parmesan cheese, Worcestershire sauce, and red pepper flakes combine to make the perfect meatball."
            };
            string[] urls =
            {
                "http://images.media-allrecipes.com/userphotos/250x250/03/59/28/3592821.jpg",
                "http://images.media-allrecipes.com/userphotos/250x250/914962.jpg",
                "http://images.media-allrecipes.com/userphotos/250x250/03/60/93/3609313.jpg",
                "http://images.media-allrecipes.com/userphotos/250x250/2606852.jpg",
                "http://images.media-allrecipes.com/userphotos/250x250/1073730.jpg",
                "http://images.media-allrecipes.com/userphotos/250x250/46458.jpg",
                "http://images.media-allrecipes.com/userphotos/250x250/2204020.jpg",
                "http://images.media-allrecipes.com/userphotos/250x250/00/41/07/410787.jpg",
                "http://images.media-allrecipes.com/userphotos/250x250/580466.jpg",
                "http://images.media-allrecipes.com/userphotos/250x250/1411947.jpg",
                "http://images.media-allrecipes.com/userphotos/250x250/254365.jpg",
                "http://images.media-allrecipes.com/userphotos/250x250/3821005.jpg",
                "http://images.media-allrecipes.com/userphotos/250x250/395984.jpg",
                "http://images.media-allrecipes.com/userphotos/250x250/998551.jpg",
                "http://images.media-allrecipes.com/userphotos/250x250/397070.jpg"
            };

            string[] descriptions =
            {
                "Despite the awkward name, this fast and user-friendly wet rub did a fine job flavoring some carne asada I grilled recently (yes, that was redundant). I'm calling it Spanish mustard since I spiked the Dijon with a couple of my favorite ingredients of all time: smoked paprika and sherry vinegar. You can use any thin flap meat (flap steak, skirt steak, round steak) instead of the flank steak.",
                "Why compromise the banana flavor? This banana bread is moist and delicious with loads of banana flavor! Friends and family love my recipe and say it's by far the best! It's wonderful toasted!! Enjoy!",
                "This salad is perfect for hot summer months! The sweet and tangy taste is very addictive.",
                "Well-rounded seafood and pasta dish. Good with any pasta; angel hair is less filling.",
                "This is one of the best comfort meals I have ever had. It is so creamy and delicious you won't want to stop eating.",
                "Ever wish you could get that restaurant-style rotisserie chicken at home? Well, with minimal preparation and about 5 hours' cooking time (great for the weekends!) you can! I don't bother to baste the bird, though some like to for the first hour. The pan juices always caramelize at the bottom, and the chicken will turn golden brown...fall-off-the-bone good!",
                "A quick and easy chicken and broccoli dish that all will love!",
                "This is a very flavorful pasta salad. The crisp cooked bacon really adds a nice flavor. I get requests for this pasta salad for every get together and cook out.",
                "This is the crispiest, spiciest, homemade fried chicken I have ever tasted! It is equally good served hot or cold and has been a picnic favorite in my family for years.",
                "I have used it often. It's easy and uses pantry staples. Always a hit with adults and kids. Serve with basmati rice or quinoa and steamed or roasted vegetables.",
                "A simple yet creative chicken meal mimics the popular Italian appetizer 'bruschetta' for a delicious entree reminiscent of romantic Italian evenings.",
                "This is a great recipe that I found in my Grandma's recipe book. Judging from the weathered look of this recipe card, this was a family favorite.",
                "I don't know where I got this recipe, but I have been using it for well over 20 years. Works well in a slow cooker.",
                "An easy and delicious way to prepare tender barbecued ribs without the barbecue!",
                "These meatballs are a compilation of many, many meatball recipes to finally achieve what I was looking for... Meatball Nirvana! Cover with your favorite red sauce and serve with pasta or in crusty garlic bread rolls."
            };

            int[] serving = { 4, 12, 10, 6, 4, 8, 6, 10, 6, 4, 6, 8, 8, 8, 4 };
            int[] times = { 50, 80, 75, 40, 35, 570, 40, 85, 50, 370, 50, 20, 60, 460, 40 };
            string[] ingredient =
            {
                "1/4 cup sherry vinegar;1/4 cup light olive oil;2 tablespoons Dijon mustard;2 tablespoons smoked paprika;4 cloves garlic, minced (optional);salt and ground black pepper to taste;2 pounds very thin flank steak",
                "2 cups all-purpose flour;1 teaspoon baking soda;1/4 teaspoon salt;1/2 cup butter;3/4 cup brown sugar;2 eggs, beaten;2 1/3 cups mashed overripe bananas",
                "8 cups broccoli florets;3 cooked skinless, boneless chicken breast halves, cubed;1 cup chopped walnuts;6 green onions, chopped;1 cup mayonnaise;1/4 cup apple cider vinegar;1/4 cup white sugar;1/4 cup crumbled cooked bacon",
                "1 (16 ounce) package linguine pasta;2 tablespoons extra-virgin olive oil;2 shallots, finely diced;2 cloves garlic, minced;1 pinch red pepper flakes (optional);1 pound shrimp, peeled and deveined;1 pinch kosher salt and freshly ground pepper;1/2 cup dry white wine;1 lemon, juiced;2 tablespoons butter;2 tablespoons extra-virgin olive oil;1/4 cup finely chopped fresh parsley leaves",
                "4 thick-cut pork chops;1 teaspoon Montreal steak seasoning, or to taste;1/2 cup butter, divided;2 1/2 tablespoons all-purpose flour, or as needed;1 tablespoon dried basil;1 teaspoon instant beef bouillon granules;1 teaspoon freshly ground black pepper;2 cups milk",
                "4 teaspoons salt;2 teaspoons paprika;1 teaspoon onion powder;1 teaspoon dried thyme;1 teaspoon white pepper;1/2 teaspoon cayenne pepper;1/2 teaspoon black pepper;1/2 teaspoon garlic powder;2 onions, quartered;2 (4 pound) whole chickens",
                "1 pound chopped fresh broccoli;1 1/2 cups cubed, cooked chicken meat;1 (10.75 ounce) can condensed cream of broccoli soup;1/3 cup milk;1/2 cup shredded Cheddar cheese;1 tablespoon butter, melted;2 tablespoons dried bread crumbs",
                "1 (12 ounce) package uncooked tri-color rotini pasta;10 slices bacon;1 cup mayonnaise;3 tablespoons dry ranch salad dressing mix;1/4 teaspoon garlic powder;1/2 teaspoon garlic pepper;1/2 cup milk, or as needed;1 large tomato, chopped;1 (4.25 ounce) can sliced black olives;1 cup shredded sharp Cheddar cheese",
                "3 cups all-purpose flour;1 1/2 tablespoons garlic salt;1 tablespoon ground black pepper;1 tablespoon paprika;1/2 teaspoon poultry seasoning;1 1/3 cups all-purpose flour;1 teaspoon salt;1/4 teaspoon ground black pepper;2 egg yolks, beaten;1 1/2 cups beer or water;1 quart vegetable oil for frying;1 (3 pound) whole chicken, cut into pieces",
                "4 skinless, boneless chicken thighs;1/2 cup soy sauce;1/2 cup ketchup;1/3 cup honey;3 cloves garlic, minced;1 teaspoon dried basil",
                "1 1/2 pounds skinless, boneless chicken breast halves - cubed;1 teaspoon salt;1 (15 ounce) can diced tomatoes with juice;1/2 cup water;1 tablespoon minced garlic;1 (6 ounce) box chicken-flavored dry bread stuffing mix;2 cups shredded mozzarella cheese;1 tablespoon Italian seasoning",
                "1 1/2 cups all-purpose flour;3 1/2 teaspoons baking powder;1 teaspoon salt;1 tablespoon white sugar;1 1/4 cups milk;1 egg;3 tablespoons butter, melted",
                "2/3 cup water;1/3 cup uncooked white rice;8 cabbage leaves;1 pound lean ground beef;1/4 cup chopped onion;1 egg, slightly beaten;1 teaspoon salt;1/4 teaspoon ground black pepper;1 (10.75 ounce) can condensed tomato soup",
                "4 pounds pork baby back ribs salt and pepper to taste;2 cups ketchup;1 cup chili sauce;1/2 cup packed brown sugar;4 tablespoons vinegar;2 teaspoons dried oregano;2 teaspoons Worcestershire sauce;1 dash hot sauce",
                "1 pound extra lean ground beef;1/2 teaspoon sea salt;1 small onion, diced;1/2 teaspoon garlic salt;1 1/2 teaspoons Italian seasoning;3/4 teaspoon dried oregano;3/4 teaspoon crushed red pepper flakes;1 dash hot pepper sauce (such as Frank's RedHot®), or to taste;1 1/2 tablespoons Worcestershire sauce;1/3 cup skim milk;1/4 cup grated Parmesan cheese;1/2 cup seasoned bread crumbs"
            };

            string[] direction =
            {
                "Preheat an outdoor grill for high heat, and lightly oil the grate.;Whisk sherry vinegar, olive oil, mustard, paprika, garlic, salt, and pepper together in a large bowl. Place steak in marinade and turn to coat. Marinate at room temperature for 30 minutes.;Cook steak on the preheated grill, turning once, until each side is browned, steak is beginning to firm, and is hot and slightly pink in the center, about 2 minutes per side.An instant - read thermometer inserted into the center should read 140 degrees F(60 degrees C).Transfer steak to a plate and let rest for 5 to 10 minutes before slicing.",
                "Preheat oven to 350 degrees F (175 degrees C). Lightly grease a 9x5 inch loaf pan.;In a large bowl, combine flour, baking soda and salt. In a separate bowl, cream together butter and brown sugar. Stir in eggs and mashed bananas until well blended. Stir banana mixture into flour mixture; stir just to moisten. Pour batter into prepared loaf pan.;Bake in preheated oven for 60 to 65 minutes, until a toothpick inserted into center of the loaf comes out clean.Let bread cool in pan for 10 minutes, then turn out onto a wire rack.",
                "Combine broccoli, chicken, walnuts, and green onions in a large bowl.;Whisk mayonnaise, vinegar, and sugar together in a bowl until well blended.;Pour mayonnaise dressing over broccoli mixture; toss to coat.;Cover and refrigerate until chilled, if desired.Sprinkle with crumbled bacon to serve.",
                "Bring a large pot of salted water to a boil; cook linguine in boiling water until nearly tender, 6 to 8 minutes. Drain.;Melt 2 tablespoons butter with 2 tablespoons olive oil in a large skillet over medium heat. Cook and stir shallots, garlic, and red pepper flakes in the hot butter and oil until shallots are translucent, 3 to 4 minutes. Season shrimp with kosher salt and black pepper; add to the skillet and cook until pink, stirring occasionally, 2 to 3 minutes.Remove shrimp from skillet and keep warm.;Pour white wine and lemon juice into skillet and bring to a boil while scraping the browned bits of food off of the bottom of the skillet with a wooden spoon. Melt 2 tablespoons butter in skillet, stir 2 tablespoons olive oil into butter mixture, and bring to a simmer. Toss linguine, shrimp, and parsley in the butter mixture until coated; season with salt and black pepper. Drizzle with 1 teaspoon olive oil to serve.",
                "Season pork chops on all sides with Montreal steak seasoning.;Melt 2 tablespoons butter in a large skillet over medium heat. Cook chops in melted butter until browned and slightly pink in the center, about 7 to 10 minutes per side. An instant-read thermometer inserted into the center should read at least 145 degrees F (63 degrees C). Add remaining butter to the pan as needed so that about 3 tablespoons pan drippings remain in the pan when the chops are finished cooking. Transfer pork chops to a plate and return skillet to medium-high heat.;Mix flour, basil, and beef bouillon together in a bowl. Stir black pepper into skillet with the pan drippings and cook for 1 minute.Add flour mixture and cook, stirring constantly, until browned, about 2 minutes.Pour milk into flour mixture; cook and stir constantly until mixture is thick and bubbly, 4 to 6 minutes.Pour sauce over pork chops and serve.",
                "In a small bowl, mix together salt, paprika, onion powder, thyme, white pepper, black pepper, cayenne pepper, and garlic powder. Remove and discard giblets from chicken. Rinse chicken cavity, and pat dry with paper towel. Rub each chicken inside and out with spice mixture. Place 1 onion into the cavity of each chicken. Place chickens in a resealable bag or double wrap with plastic wrap. Refrigerate overnight, or at least 4 to 6 hours.;Preheat oven to 250 degrees F (120 degrees C).;Place chickens in a roasting pan. Bake uncovered for 5 hours, to a minimum internal temperature of 180 degrees F(85 degrees C). Let the chickens stand for 10 minutes before carving.",
                "Preheat oven to 450 degrees F (230 degrees C).;Place the broccoli in a saucepan with enough water to cover. Bring to a boil, and cook 5 minutes, or until tender. Drain.;Place the cooked broccoli in a 9 inch pie plate. Top with the chicken. In a bowl, mix the soup and milk, and pour over the chicken. Sprinkle with Cheddar cheese. Mix the melted butter with the bread crumbs, and sprinkle over the cheese.;Bake in the preheated oven for 15 minutes, or until bubbly and lightly brown.",
                "Bring a large pot of lightly salted water to a boil; cook rotini at a boil until tender yet firm to the bite, about 8 minutes; drain.;Place bacon in a skillet over medium-high heat and cook until evenly brown. Drain and chop.;In a large bowl, mix mayonnaise, ranch dressing mix, garlic powder, and garlic pepper. Stir in milk until smooth. Place rotini, bacon, tomato, black olives and cheese in bowl and toss to coat with dressing. Cover and chill at least 1 hour in the refrigerator. Toss with additional milk if the salad seems a little dry.",
                "In one medium bowl, mix together 3 cups of flour, garlic salt, 1 tablespoon black pepper, paprika and poultry seasoning. In a separate bowl, stir together 1 1/3 cups flour, salt, 1/4 teaspoon pepper, egg yolks and beer. You may need to thin with additional beer if the batter is too thick.;Heat the oil in a deep-fryer to 350 degrees F (175 degrees C). Moisten each piece of chicken with a little water, then dip in the dry mix. Shake off excess and dip in the wet mix, then dip in the dry mix once more.;Carefully place the chicken pieces in the hot oil. Fry for 15 to 18 minutes, or until well browned.Smaller pieces will not take as long. Large pieces may take longer.Remove and drain on paper towels before serving.",
                "Lay chicken thighs into the bottom of a 4-quart slow cooker.;Whisk soy sauce, ketchup, honey, garlic, and basil together in a bowl; pour over the chicken.;Cook on Low for 6 hours.",
                "Preheat oven to 400 degrees F (200 degrees C). Spray a 9x13-inch glass baking dish with cooking spray.;Toss the cubed chicken with the salt in a large bowl. Place the chicken in a layer into the bottom of the baking dish. Stir together tomatoes, water, garlic, and stuffing mix in a large bowl; set aside to soften. Sprinkle the cheese on top of the chicken, then sprinkle with the Italian seasoning.Spread the softened stuffing mixture on top.;Bake uncovered until the chicken cubes have turned white and are no longer pink in the center, about 30 minutes.",
                "In a large bowl, sift together the flour, baking powder, salt and sugar. Make a well in the center and pour in the milk, egg and melted butter; mix until smooth.;Heat a lightly oiled griddle or frying pan over medium high heat. Pour or scoop the batter onto the griddle, using approximately 1 / 4 cup for each pancake. Brown on both sides and serve hot.",
                "In a medium saucepan, bring water to a boil. Add rice and stir. Reduce heat, cover and simmer for 20 minutes.;Bring a large, wide saucepan of lightly salted water to a boil. Add cabbage leaves and cook for 2 to 4 minutes or until softened; drain.;In a medium mixing bowl, combine the ground beef, 1 cup cooked rice, onion, egg, salt and pepper, along with 2 tablespoons of tomato soup.Mix thoroughly.;Divide the beef mixture evenly among the cabbage leaves.Roll and secure them with toothpicks or string.;In a large skillet over medium heat, place the cabbage rolls and pour the remaining tomato soup over the top.Cover and bring to a boil.Reduce heat to low and simmer for about 40 minutes, stirring and basting with the liquid often.",
                "Preheat oven to 400 degrees F (200 degrees C).;Season ribs with salt and pepper. Place in a shallow baking pan. Brown in oven 15 minutes. Turn over, and brown another 15 minutes; drain fat.;In a medium bowl, mix together the ketchup, chili sauce, brown sugar, vinegar, oregano, Worcestershire sauce, hot sauce, and salt and pepper. Place ribs in slow cooker. Pour sauce over ribs, and turn to coat.;Cover, and cook on Low 6 to 8 hours, or until ribs are tender.",
                "Preheat an oven to 400 degrees F (200 degrees C).;Place the beef into a mixing bowl, and season with salt, onion, garlic salt, Italian seasoning, oregano, red pepper flakes, hot pepper sauce, and Worcestershire sauce; mix well. Add the milk, Parmesan cheese, and bread crumbs. Mix until evenly blended, then form into 1 1 / 2 - inch meatballs, and place onto a baking sheet.;Bake in the preheated oven until no longer pink in the center, 20 to 25 minutes."
            };
            Random rand = new Random();
            for (int i = 0; i < 15; i++)
            {
                var r = new Recipe();
                r.Name = names[rand.Next(0, 15)];
                r.ShortDescription = shortDescription[rand.Next(0, 15)];
                r.Url = urls[rand.Next(0, 15)];
                r.Description = descriptions[rand.Next(0, 15)];
                r.Servings = serving[rand.Next(0, 15)];
                r.Time = times[rand.Next(0, 15)];
                r.Ingredients = ingredient[rand.Next(0, 15)];
                r.Directions = direction[rand.Next(0, 15)];
                r.CreatedBy = "Eric Andre";
                r.IsDeleted = false;
                context.Recipes.Add(r);
            }


            context.SaveChanges();
        }
    }
}
