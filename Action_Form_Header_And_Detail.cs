
//MenuItem Model Class
[Enabled(nameof(IdMaskingEnabled))]
[Visible(nameof(ID_MaskingVisible))]
[Label("Cash and Protested Tax Masking")]
[RecalculateAllOnChange]
[InputType(InputTypeAttribute.Button)]
[RecalculateMethod(nameof(ID_MaskingClick))]
public bool? ID_Masking {get; set;}
public void ID_MaskingClick()
{
	if (MTPFCntyWideMasks == null)
	{
		MTPFCntyWideMasks = new MTPFCntyWideMasks();
		MTPFCntyWideMasks.PromptForm_ShowPromptForm(true);
	}
	MetadataAction action = MetadataAction.CreateActionWithValidate("", MTPFCntyWideMasksFormMetadata.CreateView());
	bool response = VerificationQuestionHelper.ShowAction(nameof(MTPFCntyWideMasks), action, new Dictionary<string, object>(){{nameof(MTPFCntyWideMasks), MTPFCntyWideMasks}},true);
	if (response)
	{
		MTPFCntyWideMasks.cmdOK_Click();

	}
	MTPFCntyWideMasks = null;
}


//ACTION FormMetadata
public static IViewMetadata CreateView()
{
	List<IViewMetadata> CreateView = new List<IViewMetadata>();
	CreateView.Add(CreateHeaderView());
	CreateView.Add(CreateActionActionMTPFCntyWideMasksView());
	return new CombinedViewMetadata("", CreateView.ToArray()) {CantSave = false, ImmediateDelete = true, SingleCard = true};
}

public static IViewMetadata CreateHeaderView()
{
	var CreateView = new ViewMetadata("", new PropertyAugmentor<MTMtCountyWideSchoolFundsFormFp6bMenuItem>()
	{
		{PropertyAugmentor.CreateHeader("County Wide Account Masking Listing"), 100},
	}.GenerateMetadata());
	CreateView.SubPropertyName = nameof(MTPFCntyWideMasks);
	CreateView.HelpId = "frmMTPFCntyWideMasks";
	return CreateView;
}
public static IViewMetadata CreateActionActionMTPFCntyWideMasksView()
{
	var CreateActionActionMTPFCntyWideMasksView = new CellEditGridViewMetadata("")
	{
		GridProperties = new GridMetadata()
		{
			ClassMetadata = new PropertyAugmentor<MTPFCntyWideMasksGhGridMain>()
			{
				{nameof(MTPFCntyWideMasksGhGridMain.MaskType), 33},
				{nameof(MTPFCntyWideMasksGhGridMain.AcctMask), 33},
				{nameof(MTPFCntyWideMasksGhGridMain.AcctDesc), 33},
			}.GenerateMetadata(),
			MaxRowLimit = true,
			MaxRowMessage = $"{{{nameof(BaseIVMenuItem.MaxResultMessage)}}}",
			CanAdd = AccessMgr.HasAccess(MenuItem.MTMtCountyWideSchoolFundsFormFp6b, AccessMgr.Edit) && Context.FYModel.GLGlobalParms.Any(x => x.DistrictState == "MT"),
			CanEdit = AccessMgr.HasAccess(MenuItem.MTMtCountyWideSchoolFundsFormFp6b, AccessMgr.Edit) && Context.FYModel.GLGlobalParms.Any(x => x.DistrictState == "MT"),
			CanDelete = AccessMgr.HasAccess(MenuItem.MTMtCountyWideSchoolFundsFormFp6b, AccessMgr.Edit) && Context.FYModel.GLGlobalParms.Any(x => x.DistrictState == "MT"),
			Sort = SortProperty.IgnoreSort(),
		},
		SubPropertyName = $"{nameof(MTPFCntyWideMasks)}.{nameof(MTPFCntyWideMasks.ghGridMain)}",
	};
	CreateActionActionMTPFCntyWideMasksView.ParentColumnName = nameof(MTPFCntyWideMasks.MenuId);
	CreateActionActionMTPFCntyWideMasksView.ChildColumnName = nameof(MTPFCntyWideMasksGhGridMain.MenuId);
	CreateActionActionMTPFCntyWideMasksView.HelpId = "frmMTPFCntyWideMasks";
	return CreateActionActionMTPFCntyWideMasksView;
}