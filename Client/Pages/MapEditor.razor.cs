using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Configuration;
using MudBlazor;
using Options.Models;
using System;

namespace Options.Pages
{
  public partial class MapEditor
  {
    [Inject] ISnackbar Snackbar { get; set; }
    [Inject] IDialogService ModalService { get; set; }
    [Inject] IConfiguration Configuration { get; set; }

    [CascadingParameter] MudDialogInstance Popup { get; set; }

    protected virtual MapInputModel InputModel { get; set; } = new MapInputModel
    {
      Name = "SPY",
      Group = "Yes",
      Range = new(DateTime.Now.Date, DateTime.Now.AddDays(5).Date),
      Expression = "(CVolume - COpenInterest) * CGamma - (PVolume - POpenInterest) * PGamma"
    };

    protected virtual DateRange Dates { get; set; } = new(DateTime.Now.Date, DateTime.Now.AddDays(5).Date);
    protected virtual EditContext InputContext { get; set; }
    protected override void OnInitialized() => InputContext = new(InputModel);
    protected virtual void OnSuccess() => Popup.Close(DialogResult.Ok(InputModel));
    protected virtual void OnClose() => Popup.Cancel();
  }
}
