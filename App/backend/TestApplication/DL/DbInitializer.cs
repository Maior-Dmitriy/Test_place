using DL.Context;
using Model.DL;
using System.Collections.Generic;
using System.Linq;

namespace DL
{
    public static class DbInitializer
    {
        public static void Initializer(MsSqlContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            RoleEntity[] roles = new RoleEntity[]
            {
                new RoleEntity{Title = "Admin"},
                new RoleEntity{Title = "User"}
            };

            foreach(var item in roles)
            {
                context.Roles.Add(item);
            }

            UserEntity[] users = new UserEntity[]
            {
                new UserEntity {Email = "admin@gmail.com", Password = "b+wqlgHVs1gclPIVD8B/o9bkWAgHlCg1S4aOQSt25rs=", Roles = new List<RoleEntity>() { roles[0] } }, //test12345
                new UserEntity {Email = "user1@gmail.com", Password = "b+wqlgHVs1gclPIVD8B/o9bkWAgHlCg1S4aOQSt25rs=", Roles = new List<RoleEntity>() { roles[1] } },
                new UserEntity {Email = "user2@gmail.com", Password = "b+wqlgHVs1gclPIVD8B/o9bkWAgHlCg1S4aOQSt25rs=", Roles = new List<RoleEntity>() { roles[1] } }
            };

            foreach (var item in users)
            {
                context.Users.Add(item);
            }

            TestEntity[] tests = new TestEntity[]
            {
                new TestEntity {Name = "Math", Description = "Math expression resolving", Users = new List<UserEntity>() { users[0], users[1]} },
                new TestEntity {Name = "English", Description = "English gramma", Users = new List<UserEntity>() { users[0], users[1]} },
                new TestEntity {Name = "English-2",  Description = "English gramma part-2", Users = new List<UserEntity>() { users[0], users[2]} },
                new TestEntity {Name = "Math-2", Description = "Math expression resolving part-2", Users = new List<UserEntity>() { users[0], users[2]} },
                new TestEntity {Name = "Psychology", Description = "Psychology health test", Users = new List<UserEntity>() { users[0], users[2]} },
            };

            foreach (var item in tests)
            {
                context.Tests.Add(item);
            }

            QuestionEntity [] questions = new QuestionEntity []
            {
                new QuestionEntity  {Title= "Math question 1 ?", Test = tests[0] },
                new QuestionEntity  {Title= "Math question 2 ?", Test = tests[0] },
                new QuestionEntity  {Title= "Math question 3 ?", Test = tests[0] },
                new QuestionEntity  {Title= "English question 1 ?",Test = tests[1] },
                new QuestionEntity  {Title= "English question 2 ?",Test = tests[1]},
                new QuestionEntity  {Title= "English question 3 ?",Test = tests[1] },
                new QuestionEntity  {Title= "English part 2 question 1 ?", Test = tests[2] },
                new QuestionEntity  {Title= "English part 2  question 2 ?",Test = tests[2] },
                new QuestionEntity  {Title= "English part 2  question 3 ?",Test = tests[2] },
                new QuestionEntity  {Title= "Math part 2 question 1 ?", Test = tests[3] },
                new QuestionEntity  {Title= "Math part 2 question 2 ?", Test = tests[3]},
                new QuestionEntity  {Title= "Math part 2 question 3 ?", Test = tests[3]},
                new QuestionEntity  {Title= "Psychology question 1 ?", Test = tests[4]},
                new QuestionEntity  {Title= "Psychology question 2 ?", Test = tests[4]},
                new QuestionEntity  {Title= "Psychology question 3 ?", Test = tests[4]},
            };

            foreach (var item in questions)
            {
                context.Questions.Add(item);
            }

            OptionEntity[] options = new OptionEntity[]
            {
                new OptionEntity {Letter = 'A', Text= "Math-1 option 1", IsRight = false, Question = questions[0]},
                new OptionEntity {Letter = 'B', Text= "Math-1 option 2", IsRight = true, Question = questions[0]},
                new OptionEntity {Letter = 'C', Text= "Math-1 option 3", IsRight = false, Question = questions[0]},
                new OptionEntity {Letter = 'A', Text= "Math-2 option 1", IsRight = false, Question = questions[1]},
                new OptionEntity {Letter = 'B', Text= "Math-2 option 2", IsRight = true, Question = questions[1]},
                new OptionEntity {Letter = 'C', Text= "Math-2 option 3", IsRight = false, Question = questions[1]},
                new OptionEntity {Letter = 'A', Text= "Math-3 option 1", IsRight = false, Question = questions[2]},
                new OptionEntity {Letter = 'B', Text= "Math-3 option 2", IsRight = true, Question = questions[2]},
                new OptionEntity {Letter = 'C', Text= "Math-3 option 3", IsRight = false, Question = questions[2]},

                new OptionEntity {Letter = 'A', Text= "English-1 option 1", IsRight = false, Question = questions[3]},
                new OptionEntity {Letter = 'B', Text= "English-1 option 2", IsRight = true, Question = questions[3]},
                new OptionEntity {Letter = 'C', Text= "English-1 option 3", IsRight = false, Question = questions[3]},
                new OptionEntity {Letter = 'A', Text= "English-2 option 1", IsRight = false, Question = questions[4]},
                new OptionEntity {Letter = 'B', Text= "English-2 option 2", IsRight = true, Question = questions[4]},
                new OptionEntity {Letter = 'C', Text= "English-2 option 3", IsRight = false, Question = questions[4]},
                new OptionEntity {Letter = 'A', Text= "English-3 option 1", IsRight = false, Question = questions[5]},
                new OptionEntity {Letter = 'B', Text= "English-3 option 2", IsRight = true, Question = questions[5]},
                new OptionEntity {Letter = 'C', Text= "English-3 option 3", IsRight = false, Question = questions[5]},

                new OptionEntity {Letter = 'A', Text= "English part2-1 option 1", IsRight = false, Question = questions[6]},
                new OptionEntity {Letter = 'B', Text= "English part2-1 option 2", IsRight = true, Question = questions[6]},
                new OptionEntity {Letter = 'C', Text= "English part2-1 option 3", IsRight = false, Question = questions[6]},
                new OptionEntity {Letter = 'A', Text= "English part2-2 option 1", IsRight = false, Question = questions[7]},
                new OptionEntity {Letter = 'B', Text= "English part2-2 option 2", IsRight = true, Question = questions[7]},
                new OptionEntity {Letter = 'C', Text= "English part2-2 option 3", IsRight = false, Question = questions[7]},
                new OptionEntity {Letter = 'A', Text= "English part2-3 option 1", IsRight = false, Question = questions[8]},
                new OptionEntity {Letter = 'B', Text= "English part2-3 option 2", IsRight = true, Question = questions[8]},
                new OptionEntity {Letter = 'C', Text= "English part2-3 option 3", IsRight = false, Question = questions[8]},

                new OptionEntity {Letter = 'A', Text= "Math part2-1 option 1", IsRight = false, Question = questions[9]},
                new OptionEntity {Letter = 'B', Text= "Math part2-1 option 2", IsRight = true, Question = questions[9]},
                new OptionEntity {Letter = 'C', Text= "Math part2-1 option 3", IsRight = false, Question = questions[9]},
                new OptionEntity {Letter = 'A', Text= "Math part2-2 option 1", IsRight = false, Question = questions[10]},
                new OptionEntity {Letter = 'B', Text= "Math part2-2 option 2", IsRight = true, Question = questions[10]},
                new OptionEntity {Letter = 'C', Text= "Math part2-2 option 3", IsRight = false, Question = questions[10]},
                new OptionEntity {Letter = 'A', Text= "Math part2-3 option 1", IsRight = false, Question = questions[11]},
                new OptionEntity {Letter = 'B', Text= "Math part2-3 option 2", IsRight = true, Question = questions[11]},
                new OptionEntity {Letter = 'C', Text= "Math part2-3 option 3", IsRight = false, Question = questions[11]},

                new OptionEntity {Letter = 'A', Text= "Psychology-1 option 1", IsRight = false, Question = questions[12]},
                new OptionEntity {Letter = 'B', Text= "Psychology-1 option 2", IsRight = true, Question = questions[12]},
                new OptionEntity {Letter = 'C', Text= "Psychology-1 option 3", IsRight = false, Question = questions[12]},
                new OptionEntity {Letter = 'A', Text= "Psychology-2 option 1", IsRight = false, Question = questions[13]},
                new OptionEntity {Letter = 'B', Text= "Psychology-2 option 2", IsRight = true, Question = questions[13]},
                new OptionEntity {Letter = 'C', Text= "Psychology-2 option 3", IsRight = false, Question = questions[13]},
                new OptionEntity {Letter = 'A', Text= "Psychology-3 option 1", IsRight = false, Question = questions[14]},
                new OptionEntity {Letter = 'B', Text= "Psychology-3 option 2", IsRight = true, Question = questions[14]},
                new OptionEntity {Letter = 'C', Text= "Psychology-3 option 3", IsRight = false, Question = questions[14]},
            };

            foreach (var item in options)
            {
                context.Options.Add(item);
            }

            context.SaveChanges();
        }
    }
}
