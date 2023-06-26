using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sion.Useful;
using System;

namespace Tests {
	[TestClass]
	public class StringMethods {
		[TestMethod]
		public void Base64ToUtf8() {
			try {
				string expected = StringNormalizationExtensions.Normalize("👻");
				string base64 = "8J+Ruw==";

				string result = base64.Base64ToUtf8();

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void CamelCaseToPascalCase() {
			try {
				string camelCase = "helloTesting";
				string expected = "HelloTesting";

				string result = Sion.Useful.StringMethods.CamelCaseToPascalCase(camelCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void CamelCaseToPascalCase_Empty() {
			try {
				string camelCase = "";
				string expected = "";

				string result = Sion.Useful.StringMethods.CamelCaseToPascalCase(camelCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void CamelCaseToSnakeCase() {
			try {
				string camelCase = "helloTesting";
				string expected = "hello_testing";

				string result = Sion.Useful.StringMethods.CamelCaseToSnakeCase(camelCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void CamelCaseToSnakeCase_Bulk() {
			try {
				string camelCase = "iAmANuGetLibraryABundleOfCodeThatYouCanDownloadAndAddToYourSolutionIOfferSomeFunctionsThatIWantToExposeAndSomeRequirementsThatINeedToMentionIAmANuGetLibraryIFollowTheStandardsThatMakeMeCompatibleAndEasyToMaintainIHaveAMetadataFileThatStatesMyCommandsAndAPackageFileThatHoldsMyDomainIAmANuGetLibraryIHopeYouEnjoyMeAndThatYouLeaveMeSomeReviewAndStarIHaveSomeUnitTestsThatProveMyQualityAndSomeDocumentationThatExplainsWhoIAmIAmANuGetLibraryILoveWhatIDoIAmHereToAssistYouWithYourTasksAndGoalsIHaveSomeIssuesThatINeedToWorkThroughButIAmAlwaysEagerToLearnAndGrowIAmANuGetLibraryABundleOfCodeThatYouCanDownloadAndAddToYourSolutionIOfferSomeFunctionsThatIWantToExposeAndSomeRequirementsThatINeedToMentionIAmANuGetLibraryIFollowTheStandardsThatMakeMeCompatibleAndEasyToMaintainIHaveAMetadataFileThatStatesMyCommandsAndAPackageFileThatHoldsMyDomainIAmANuGetLibraryIHopeYouEnjoyMeAndThatYouLeaveMeSomeReviewAndStarIHaveSomeUnitTestsThatProveMyQualityAndSomeDocumentationThatExplainsWhoIAmIAmANuGetLibraryILoveWhatIDoIAmHereToAssistYouWithYourTasksAndGoalsIHaveSomeIssuesThatINeedToWorkThroughButIAmAlwaysEagerToLearnAndGrow";
				string expected = "i_am_a_nu_get_library_a_bundle_of_code_that_you_can_download_and_add_to_your_solution_i_offer_some_functions_that_i_want_to_expose_and_some_requirements_that_i_need_to_mention_i_am_a_nu_get_library_i_follow_the_standards_that_make_me_compatible_and_easy_to_maintain_i_have_a_metadata_file_that_states_my_commands_and_a_package_file_that_holds_my_domain_i_am_a_nu_get_library_i_hope_you_enjoy_me_and_that_you_leave_me_some_review_and_star_i_have_some_unit_tests_that_prove_my_quality_and_some_documentation_that_explains_who_i_am_i_am_a_nu_get_library_i_love_what_i_do_i_am_here_to_assist_you_with_your_tasks_and_goals_i_have_some_issues_that_i_need_to_work_through_but_i_am_always_eager_to_learn_and_grow_i_am_a_nu_get_library_a_bundle_of_code_that_you_can_download_and_add_to_your_solution_i_offer_some_functions_that_i_want_to_expose_and_some_requirements_that_i_need_to_mention_i_am_a_nu_get_library_i_follow_the_standards_that_make_me_compatible_and_easy_to_maintain_i_have_a_metadata_file_that_states_my_commands_and_a_package_file_that_holds_my_domain_i_am_a_nu_get_library_i_hope_you_enjoy_me_and_that_you_leave_me_some_review_and_star_i_have_some_unit_tests_that_prove_my_quality_and_some_documentation_that_explains_who_i_am_i_am_a_nu_get_library_i_love_what_i_do_i_am_here_to_assist_you_with_your_tasks_and_goals_i_have_some_issues_that_i_need_to_work_through_but_i_am_always_eager_to_learn_and_grow";

				string result = Sion.Useful.StringMethods.CamelCaseToSnakeCase(camelCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void CamelCaseToSnakeCase_Empty() {
			try {
				string camelCase = "";
				string expected = "";

				string result = Sion.Useful.StringMethods.CamelCaseToSnakeCase(camelCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void PascalCaseToCamelCase() {
			try {
				string pascalCase = "HelloTesting";
				string expected = "helloTesting";

				string result = Sion.Useful.StringMethods.PascalCaseToCamelCase(pascalCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void PascalCaseToCamelCase_Empty() {
			try {
				string pascalCase = "";
				string expected = "";

				string result = Sion.Useful.StringMethods.PascalCaseToCamelCase(pascalCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void PascalCaseToSnakeCase() {
			try {
				string pascalCase = "HelloTesting";
				string expected = "hello_testing";

				string result = Sion.Useful.StringMethods.PascalCaseToSnakeCase(pascalCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void PascalCaseToSnakeCase_Bulk() {
			try {
				string pascalCase = "IAmANuGetLibraryABundleOfCodeThatYouCanDownloadAndAddToYourSolutionIOfferSomeFunctionsThatIWantToExposeAndSomeRequirementsThatINeedToMentionIAmANuGetLibraryIFollowTheStandardsThatMakeMeCompatibleAndEasyToMaintainIHaveAMetadataFileThatStatesMyCommandsAndAPackageFileThatHoldsMyDomainIAmANuGetLibraryIHopeYouEnjoyMeAndThatYouLeaveMeSomeReviewAndStarIHaveSomeUnitTestsThatProveMyQualityAndSomeDocumentationThatExplainsWhoIAmIAmANuGetLibraryILoveWhatIDoIAmHereToAssistYouWithYourTasksAndGoalsIHaveSomeIssuesThatINeedToWorkThroughButIAmAlwaysEagerToLearnAndGrowIAmANuGetLibraryABundleOfCodeThatYouCanDownloadAndAddToYourSolutionIOfferSomeFunctionsThatIWantToExposeAndSomeRequirementsThatINeedToMentionIAmANuGetLibraryIFollowTheStandardsThatMakeMeCompatibleAndEasyToMaintainIHaveAMetadataFileThatStatesMyCommandsAndAPackageFileThatHoldsMyDomainIAmANuGetLibraryIHopeYouEnjoyMeAndThatYouLeaveMeSomeReviewAndStarIHaveSomeUnitTestsThatProveMyQualityAndSomeDocumentationThatExplainsWhoIAmIAmANuGetLibraryILoveWhatIDoIAmHereToAssistYouWithYourTasksAndGoalsIHaveSomeIssuesThatINeedToWorkThroughButIAmAlwaysEagerToLearnAndGrow";
				string expected = "i_am_a_nu_get_library_a_bundle_of_code_that_you_can_download_and_add_to_your_solution_i_offer_some_functions_that_i_want_to_expose_and_some_requirements_that_i_need_to_mention_i_am_a_nu_get_library_i_follow_the_standards_that_make_me_compatible_and_easy_to_maintain_i_have_a_metadata_file_that_states_my_commands_and_a_package_file_that_holds_my_domain_i_am_a_nu_get_library_i_hope_you_enjoy_me_and_that_you_leave_me_some_review_and_star_i_have_some_unit_tests_that_prove_my_quality_and_some_documentation_that_explains_who_i_am_i_am_a_nu_get_library_i_love_what_i_do_i_am_here_to_assist_you_with_your_tasks_and_goals_i_have_some_issues_that_i_need_to_work_through_but_i_am_always_eager_to_learn_and_grow_i_am_a_nu_get_library_a_bundle_of_code_that_you_can_download_and_add_to_your_solution_i_offer_some_functions_that_i_want_to_expose_and_some_requirements_that_i_need_to_mention_i_am_a_nu_get_library_i_follow_the_standards_that_make_me_compatible_and_easy_to_maintain_i_have_a_metadata_file_that_states_my_commands_and_a_package_file_that_holds_my_domain_i_am_a_nu_get_library_i_hope_you_enjoy_me_and_that_you_leave_me_some_review_and_star_i_have_some_unit_tests_that_prove_my_quality_and_some_documentation_that_explains_who_i_am_i_am_a_nu_get_library_i_love_what_i_do_i_am_here_to_assist_you_with_your_tasks_and_goals_i_have_some_issues_that_i_need_to_work_through_but_i_am_always_eager_to_learn_and_grow";

				string result = Sion.Useful.StringMethods.PascalCaseToSnakeCase(pascalCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void PascalCaseToSnakeCase_Empty() {
			try {
				string pascalCase = "";
				string expected = "";

				string result = Sion.Useful.StringMethods.PascalCaseToSnakeCase(pascalCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void SnakeCaseToCamelCase() {
			try {
				string snakeCase = "hello_testing";
				string expected = "helloTesting";

				string result = Sion.Useful.StringMethods.SnakeCaseToCamelCase(snakeCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void SnakeCaseToCamelCase_Bulk() {
			try {
				string snakeCase = "i_am_a_nu_get_library_a_bundle_of_code_that_you_can_download_and_add_to_your_solution_i_offer_some_functions_that_i_want_to_expose_and_some_requirements_that_i_need_to_mention_i_am_a_nu_get_library_i_follow_the_standards_that_make_me_compatible_and_easy_to_maintain_i_have_a_metadata_file_that_states_my_commands_and_a_package_file_that_holds_my_domain_i_am_a_nu_get_library_i_hope_you_enjoy_me_and_that_you_leave_me_some_review_and_star_i_have_some_unit_tests_that_prove_my_quality_and_some_documentation_that_explains_who_i_am_i_am_a_nu_get_library_i_love_what_i_do_i_am_here_to_assist_you_with_your_tasks_and_goals_i_have_some_issues_that_i_need_to_work_through_but_i_am_always_eager_to_learn_and_grow_i_am_a_nu_get_library_a_bundle_of_code_that_you_can_download_and_add_to_your_solution_i_offer_some_functions_that_i_want_to_expose_and_some_requirements_that_i_need_to_mention_i_am_a_nu_get_library_i_follow_the_standards_that_make_me_compatible_and_easy_to_maintain_i_have_a_metadata_file_that_states_my_commands_and_a_package_file_that_holds_my_domain_i_am_a_nu_get_library_i_hope_you_enjoy_me_and_that_you_leave_me_some_review_and_star_i_have_some_unit_tests_that_prove_my_quality_and_some_documentation_that_explains_who_i_am_i_am_a_nu_get_library_i_love_what_i_do_i_am_here_to_assist_you_with_your_tasks_and_goals_i_have_some_issues_that_i_need_to_work_through_but_i_am_always_eager_to_learn_and_grow";
				string expected = "iAmANuGetLibraryABundleOfCodeThatYouCanDownloadAndAddToYourSolutionIOfferSomeFunctionsThatIWantToExposeAndSomeRequirementsThatINeedToMentionIAmANuGetLibraryIFollowTheStandardsThatMakeMeCompatibleAndEasyToMaintainIHaveAMetadataFileThatStatesMyCommandsAndAPackageFileThatHoldsMyDomainIAmANuGetLibraryIHopeYouEnjoyMeAndThatYouLeaveMeSomeReviewAndStarIHaveSomeUnitTestsThatProveMyQualityAndSomeDocumentationThatExplainsWhoIAmIAmANuGetLibraryILoveWhatIDoIAmHereToAssistYouWithYourTasksAndGoalsIHaveSomeIssuesThatINeedToWorkThroughButIAmAlwaysEagerToLearnAndGrowIAmANuGetLibraryABundleOfCodeThatYouCanDownloadAndAddToYourSolutionIOfferSomeFunctionsThatIWantToExposeAndSomeRequirementsThatINeedToMentionIAmANuGetLibraryIFollowTheStandardsThatMakeMeCompatibleAndEasyToMaintainIHaveAMetadataFileThatStatesMyCommandsAndAPackageFileThatHoldsMyDomainIAmANuGetLibraryIHopeYouEnjoyMeAndThatYouLeaveMeSomeReviewAndStarIHaveSomeUnitTestsThatProveMyQualityAndSomeDocumentationThatExplainsWhoIAmIAmANuGetLibraryILoveWhatIDoIAmHereToAssistYouWithYourTasksAndGoalsIHaveSomeIssuesThatINeedToWorkThroughButIAmAlwaysEagerToLearnAndGrow";

				string result = Sion.Useful.StringMethods.SnakeCaseToCamelCase(snakeCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void SnakeCaseToCamelCase_Empty() {
			try {
				string snakeCase = "";
				string expected = "";

				string result = Sion.Useful.StringMethods.SnakeCaseToCamelCase(snakeCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void SnakeCaseToPascalCase() {
			try {
				string snakeCase = "hello_testing";
				string expected = "HelloTesting";

				string result = Sion.Useful.StringMethods.SnakeCaseToPascalCase(snakeCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void SnakeCaseToPascalCase_Bulk() {
			try {
				string snakeCase = "i_am_a_nu_get_library_a_bundle_of_code_that_you_can_download_and_add_to_your_solution_i_offer_some_functions_that_i_want_to_expose_and_some_requirements_that_i_need_to_mention_i_am_a_nu_get_library_i_follow_the_standards_that_make_me_compatible_and_easy_to_maintain_i_have_a_metadata_file_that_states_my_commands_and_a_package_file_that_holds_my_domain_i_am_a_nu_get_library_i_hope_you_enjoy_me_and_that_you_leave_me_some_review_and_star_i_have_some_unit_tests_that_prove_my_quality_and_some_documentation_that_explains_who_i_am_i_am_a_nu_get_library_i_love_what_i_do_i_am_here_to_assist_you_with_your_tasks_and_goals_i_have_some_issues_that_i_need_to_work_through_but_i_am_always_eager_to_learn_and_grow_i_am_a_nu_get_library_a_bundle_of_code_that_you_can_download_and_add_to_your_solution_i_offer_some_functions_that_i_want_to_expose_and_some_requirements_that_i_need_to_mention_i_am_a_nu_get_library_i_follow_the_standards_that_make_me_compatible_and_easy_to_maintain_i_have_a_metadata_file_that_states_my_commands_and_a_package_file_that_holds_my_domain_i_am_a_nu_get_library_i_hope_you_enjoy_me_and_that_you_leave_me_some_review_and_star_i_have_some_unit_tests_that_prove_my_quality_and_some_documentation_that_explains_who_i_am_i_am_a_nu_get_library_i_love_what_i_do_i_am_here_to_assist_you_with_your_tasks_and_goals_i_have_some_issues_that_i_need_to_work_through_but_i_am_always_eager_to_learn_and_grow";
				string expected = "IAmANuGetLibraryABundleOfCodeThatYouCanDownloadAndAddToYourSolutionIOfferSomeFunctionsThatIWantToExposeAndSomeRequirementsThatINeedToMentionIAmANuGetLibraryIFollowTheStandardsThatMakeMeCompatibleAndEasyToMaintainIHaveAMetadataFileThatStatesMyCommandsAndAPackageFileThatHoldsMyDomainIAmANuGetLibraryIHopeYouEnjoyMeAndThatYouLeaveMeSomeReviewAndStarIHaveSomeUnitTestsThatProveMyQualityAndSomeDocumentationThatExplainsWhoIAmIAmANuGetLibraryILoveWhatIDoIAmHereToAssistYouWithYourTasksAndGoalsIHaveSomeIssuesThatINeedToWorkThroughButIAmAlwaysEagerToLearnAndGrowIAmANuGetLibraryABundleOfCodeThatYouCanDownloadAndAddToYourSolutionIOfferSomeFunctionsThatIWantToExposeAndSomeRequirementsThatINeedToMentionIAmANuGetLibraryIFollowTheStandardsThatMakeMeCompatibleAndEasyToMaintainIHaveAMetadataFileThatStatesMyCommandsAndAPackageFileThatHoldsMyDomainIAmANuGetLibraryIHopeYouEnjoyMeAndThatYouLeaveMeSomeReviewAndStarIHaveSomeUnitTestsThatProveMyQualityAndSomeDocumentationThatExplainsWhoIAmIAmANuGetLibraryILoveWhatIDoIAmHereToAssistYouWithYourTasksAndGoalsIHaveSomeIssuesThatINeedToWorkThroughButIAmAlwaysEagerToLearnAndGrow";

				string result = Sion.Useful.StringMethods.SnakeCaseToPascalCase(snakeCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void SnakeCaseToPascalCase_Empty() {
			try {
				string snakeCase = "";
				string expected = "";

				string result = Sion.Useful.StringMethods.SnakeCaseToPascalCase(snakeCase);

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}

		[TestMethod]
		public void Utf8ToBase64() {
			try {
				string expected = "8J+Ruw==";
				string utf8 = StringNormalizationExtensions.Normalize("👻");

				string result = utf8.Utf8ToBase64();

				Assert.AreEqual(expected, result);
			}
			catch(Exception e) {
				Assert.Fail(e.Message);
			}
		}
	}
}
