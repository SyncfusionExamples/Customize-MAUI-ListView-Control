# Customize-MAUI-ListView-Control
The .NET MAUI ListView control displays data lists in vertical and horizontal formats, offering a range of layout options. It supports dynamic data loading at runtime, which can be initiated automatically, manually, or when the user scrolls to the bottom of the list. 

This sample demonstrates how to customize the load more feature in the MAUI ListView control within a .NET MAUI application. You'll see how to enable its load-more feature with different modes, customize the position of the load-more view and the appearance of the Load More button.

## Sample

```xaml
<listview:SfListView x:Name="listView" ItemSize="100" ItemsSource="{Binding BookDetails}"
                     LoadMoreCommand="{Binding LoadMoreItemsCommand}"
                     LoadMoreOption="Manual"
                     LoadMoreCommandParameter="{Binding Source={x:Reference listView}}"
                     LoadMorePosition="End">
    <listview:SfListView.LoadMoreTemplate>
        <DataTemplate>
            <Grid HeightRequest="30" WidthRequest="200" Background="Purple">
                <Label Text="Show more..." TextColor="LightCyan"
                       FontSize="20" FontAttributes="Bold"
                       HorizontalTextAlignment="Center"
                       VerticalTextAlignment="Center"/>
            </Grid>
        </DataTemplate>
    </listview:SfListView.LoadMoreTemplate>
    <listview:SfListView.ItemTemplate>
        <DataTemplate>
            <Grid Padding="5">
                <Grid.RowDefinitions>
                    <RowDefinition Height="0.4*"/>
                    <RowDefinition Height="0.9*"/>
                </Grid.RowDefinitions>
                <Label x:Name="name" Text="{Binding Name}" Grid.Row="0" FontSize="17" FontAttributes="Bold"/>
                <Label x:Name="description" Text="{Binding Description}" Grid.Row="1" FontSize="15" />
            </Grid>
        </DataTemplate>
    </listview:SfListView.ItemTemplate>
</listview:SfListView>
```

## Requirements to run the demo

To run the demo, refer to [System Requirements for .NET MAUI](https://help.syncfusion.com/maui/system-requirements)

## Troubleshooting:
### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion's samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion's samples.